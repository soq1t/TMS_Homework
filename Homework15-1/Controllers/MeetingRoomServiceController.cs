using Microsoft.AspNetCore.Mvc;

namespace Homework15_1.Controllers
{
    [ApiController]
    [Route("MeetingRoomController")]
    public class MeetingRoomServiceController : ControllerBase
    {
        private MeetingRoom _room;

        public MeetingRoomServiceController()
        {
            _room = new MeetingRoom
            {
                Id = 1,
                Name = "Конференция Zoom",
                BeginningDateTime = new DateTime(2024, 08, 13, 19, 00, 00),
                EndingDateTime = new DateTime(2024, 08, 13, 22, 00, 00),
                PeopleAmount = 19,
                Theme = "Контроллеры"
            };
        }

        [HttpGet(Name = "GetMeetingRoom")]
        public MeetingRoom Get()
        {
            return _room;
        }
    }
}
