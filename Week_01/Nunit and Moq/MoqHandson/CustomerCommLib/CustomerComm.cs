namespace CustomerCommLib;

public class CustomerComm
{
    private readonly IMailSender _mailSender;

    public CustomerComm(IMailSender mailSender)
    {
        _mailSender = mailSender;
    }

    public bool SendMailToCustomer()
    {
        string email = "cust123@abc.com";
        string message = "Some Message";

        bool result = _mailSender.SendMail(email, message);

        return result;
    }
}