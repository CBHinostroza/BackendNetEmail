using BackendNetEmail.DTOs;
using BackendNetEmail.Helpers;
using BackendNetEmail.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendNetEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ILogger<SendEmailController> _logger;
        private readonly IEmailService _emailService;

        public SendEmailController(
            ILogger<SendEmailController> logger,
            IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        /// <param name="request">Objeto que contiene la dirección de correo electrónico del destinatario.</param>
        /// <returns>Un código HTTP 200 si la solicitud fue procesada correctamente.</returns>
        [EndpointSummary("Endpoint para enviar una notificación por correo electrónico.")]
        [HttpPost("Notification")]
        public IActionResult Notification([FromBody] EmailRequestDTO request)
        {

            string asunto = "Correo de Prueba";
            string body = EmailHelper.BodyNotification();
            List<string> destino = [];

            // Agregar correo a la lista de destinatarios
            destino.Add(request.EmailTo);

            // Enviar correo en un proceso en segundo plano
            var task = Task.Run(() =>
            {
                string resultado = _emailService.SendEmail(asunto, body, destino, null);

                // Registrar log del envío
                _logger.LogInformation("Log: {resultado}", resultado);
            });

            return Ok();
        }
    }
}
