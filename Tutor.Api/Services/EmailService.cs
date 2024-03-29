﻿using MailKit.Net.Smtp;
using MimeKit;
using Tutor.Api.Models;

namespace Tutor.Api.Services
{
    public class EmailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        internal void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        internal MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }
        internal void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        internal Boolean SendQuestionConfirmation(Guid questionId, string studentUsername)
        {
            var message = new Message(new string[] { studentUsername }, "Question Confirmation", "Your question has successfully been submitted.\nQuestion ID: " + questionId);
            try
            {
                SendEmail(message);
            }
            catch
            {
                return false;
            }
            return true;
        }
        internal Boolean SendQuestionAnswered(Guid questionId, string studentUsername)
        {
            var message = new Message(new string[] { studentUsername }, "Question Answered", "Your question has been answered.\nQuestion ID: " + questionId);
            try
            {
                SendEmail(message);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
