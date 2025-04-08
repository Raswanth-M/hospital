using HospitalAppMgnt.Models;
using HospitalAppMgnt.Repositories;
using Microsoft.AspNetCore.Mvc;
using HospitalAppMgnt.DTOs;

namespace HospitalAppMgnt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _notificationRepository.GetNotificationsAsync();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> AddNotification(NotificationDTO notificationDto)
        {
            var notification = new Notification
            {
                UserId= notificationDto.UserId,
                Message = notificationDto.Message,
                Status = notificationDto.Status
            };
            await _notificationRepository.CreateNotificationAsync(notification);
            return CreatedAtAction(nameof(GetNotificationById), new { id = notification.Id }, notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, NotificationDTO notificationDto)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            notification.UserId = notificationDto.UserId;
            notification.Message = notificationDto.Message;
            notification.Status = notificationDto.Status;
            await _notificationRepository.UpdateNotificationAsync(notification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationRepository.DeleteNotificationAsync(id);
            return NoContent();
        }
    }

}
