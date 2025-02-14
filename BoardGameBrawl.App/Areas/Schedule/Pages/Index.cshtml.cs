#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.CheckIfPlayerScheduleExists;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateSchedule;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetPlayerScheduleWithDetails;
using System.ComponentModel.DataAnnotations;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;

namespace BoardGameBrawl.App.Areas.Schedule.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public IndexModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public PlayerDTO TargetPlayer { get; set; }

        public bool IsScheduleExists { get; set; }

        public PlayerScheduleDTO PlayerSchedule { get; set; }

        [BindProperty]
        public ScheduleViewModel Schedule { get; set; }

       
        public class ScheduleViewModel
        {
            public Guid PlayerId { get; set; }
            public List<DayViewModel> Days { get; set; } = new List<DayViewModel>();
        }

        public class DayViewModel
        {
            public DayOfWeek DayOfWeek { get; set; }
            public List<TimeSlotViewModel> TimeSlots { get; set; } = new List<TimeSlotViewModel>();
        }

        public class TimeSlotViewModel
        {
            public int Id { get; set; } 

            [Required]
            [DataType(DataType.Time)]
            public TimeSpan StartTime { get; set; }

            [Required]
            [DataType(DataType.Time)]
            public TimeSpan EndTime { get; set; }
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            TargetPlayer = await _mediator.Send(query);

            // check If schedule exists
            var check = new CheckIfPlayerScheduleExistsQuery { PlayerId = TargetPlayer.Id };
            IsScheduleExists = await _mediator.Send(check);

            if (IsScheduleExists == false)
            {
                Guid newScheduleId = Guid.NewGuid();
                List<DailyAvailabilityDTO> listOfDailies = new List<DailyAvailabilityDTO>();

                // Create daily for all 7 days 
                for (DayOfWeek day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
                {
                    // create daily for every day
                        DailyAvailabilityDTO daily = new()
                    {
                        PlayerScheduleId = newScheduleId,
                        DayOfWeek = day,
                        TimeSlots = new List<TimeSlotDTO>()
                        {
                            new TimeSlotDTO()
                        }
                    };
                    listOfDailies.Add(daily);
                }

                // create new player Schedule
                PlayerScheduleDTO newScheduleDTO = new()
                {
                    Id = newScheduleId,
                    PlayerId = TargetPlayer.Id,
                    DailyAvailabilities = listOfDailies
                };

                var addNewSchedule = new AddOrUpdateScheduleCommand { PlayerScheduleDTO = newScheduleDTO };
                var result = await _mediator.Send(addNewSchedule);

                if (result.Success)
                {
                    StatusMessage = "New Player Schedule created successfully";
                    return RedirectToPage();
                }
                else
                {
                    StatusMessage = "Error during process of schedule creation";
                    return Page();
                }
            }
            else
            {
                // get Player Schedule
                var getSchedule = new GetPlayerScheduleWithDetailsQuery { PlayerId = TargetPlayer.Id };
                PlayerSchedule = await _mediator.Send(getSchedule);

                // setting ScheduleModelView nad populate it with DTO fetch data
                Schedule = new ScheduleViewModel
                {
                    PlayerId = PlayerSchedule.PlayerId,
                    Days = PlayerSchedule.DailyAvailabilities.Select(d => new DayViewModel
                    {
                        DayOfWeek = d.DayOfWeek,
                        TimeSlots = d.TimeSlots!.Select(t => new TimeSlotViewModel
                        {
                            Id = t.Id,
                            StartTime = t.StartTime,
                            EndTime = t.EndTime
                        }).ToList()
                    }).ToList()
                };

                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();


            return RedirectToPage("./Index");
        }
    }
}
