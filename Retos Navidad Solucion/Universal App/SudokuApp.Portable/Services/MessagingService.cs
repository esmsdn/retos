namespace SudokuApp.Portable.Services
{
    using GalaSoft.MvvmLight.Messaging;
    using System;

    /// <summary>
    /// El servicio de mensajería utilizado para enviar mensajes entre diferentes partes de la app (p. ej. de los vista-modelo a las vistas)
    /// </summary>
    public class MessagingService
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MessagingService"/>
        /// </summary>
        public MessagingService()
        {
        }

        /// <summary>
        /// Envía un mensaje con contenido
        /// </summary>
        /// <param name="token">El tipo del mensaje</param>
        /// <param name="message">El contenido del mensaje</param>
        public void Send(object token, object message)
        {
            Messenger.Default.Send<object>(message, token);
        }

        /// <summary>
        /// Registra un destinatario para recibir mensajes
        /// </summary>
        /// <param name="recipient">El destinatario que recibirá el mensaje</param>
        /// <param name="token">El tipo del mensaje</param>
        /// <param name="action">La acción que se ejecutará cuando se reciba el mensaje</param>
        public void Register(object recipient, object token, Action<object> action)
        {
            Messenger.Default.Register<object>(recipient, token, action);
        }

        /// <summary>
        /// Desregistra un destinatario de recibir mensajes
        /// </summary>
        /// <param name="recipient">El destinatario que recibía los mensajes</param>
        /// <param name="token">El tipo del mensaje</param>
        /// <param name="action">La acción que se ejecutaba al recibir el mensaje</param>
        public void Unregister(object recipient, object token, Action<object> action)
        {
            Messenger.Default.Unregister<object>(recipient, token, action);
        }
    }
}
