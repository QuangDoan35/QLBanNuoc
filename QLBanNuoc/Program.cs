using QLBanNuoc.Forms;

namespace QLBanNuoc
{
    public static class Program
    {
        static ApplicationContext MainContext = new ApplicationContext();

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //DangNhap dangNhap = new DangNhap();
            //dangNhap.Show();

            Form_Layout mainForm = new Form_Layout();
            mainForm.Show();

            Application.Run();
        }
    }
}