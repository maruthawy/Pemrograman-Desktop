public class UserManager
{
    private List<User> validUsers = new List<User>
    {
        new User("admin", "1234")
    };

    public string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // Jika karakter yang ditekan adalah karakter normal (bukan tombol navigasi atau fungsi)
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*"); // Tampilkan karakter pengganti
            }
            // Jika tombol backspace ditekan
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Remove(password.Length - 1);
                Console.Write("\b \b"); // Hapus karakter terakhir yang ditampilkan di layar
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine(); // Pindah ke baris baru setelah pengguna mengetik password

        return password;
    }

    public User Login()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = ReadPassword();

        Console.Clear();

        foreach (User user in validUsers)
        {
            if (user.Username == username && user.Password == password)
            {
                return user;
            }
        }

        return null;
    }
}