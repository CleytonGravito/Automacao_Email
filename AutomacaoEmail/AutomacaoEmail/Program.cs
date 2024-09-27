using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Configurações do servidor de e-mail
        string smtpServer = "smtp.gmail.com"; // Para Gmail
        int port = 587; // Porta para TLS
        string username = "Seu Email"; // Substitua pelo seu e-mail
        string password = "Sua Senha"; // Substitua pela sua senha, utilize a "senhas de app"

        EmailService emailService = new EmailService(smtpServer, port, username, password);

        // Informações do e-mail
        string toEmail = "Seu Email";
        string subject = "Lembrete: Reunião Agendada";
        string body = "<h1>Boa tarde!</h1>" + "<p>Este é um lembrete sobre a reunião marcada para amanhã às 10:00.</p>";

        // Agendar o envio para o tempo determinado
        TimeSpan delay = TimeSpan.FromSeconds(5);
        Console.WriteLine($"O e-mail será enviado em {delay.TotalSeconds} segundos...");

        await Task.Delay(delay);
        emailService.SendEmail(toEmail, subject, body);

        Console.WriteLine("E-mail foi enviado com sucesso!");

        // Espera pela entrada do usuário antes de fechar
        Console.WriteLine("Pressione Enter para sair...");
        Console.ReadLine(); // Isso mantém o console aberto
    }
}

