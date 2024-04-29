class Program
{
    static void Main(string[] args)
    {
        ShowHeader();

        UserManager userManager = new UserManager();
        ProductManager productManager = new ProductManager();



        while (true)
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Keluar");
            Console.Write("Pilih menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    ShowHeader();

                    User currentUser = userManager.Login();
                    if (currentUser != null)
                    {
                        Console.Clear();
                        ShowMainMenu(productManager);
                    }
                    else
                    {
                        ShowHeader();
                        Console.WriteLine("Username atau password salah. Silakan coba lagi.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                    return;
                default:
                    Console.Clear();
                    ShowHeader();
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }
    static void ShowHeader()
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("                 UTHAFOOD                    ");
        Console.WriteLine("     Aplikasi Pemesanan FastFood Terbaik     ");
        Console.WriteLine("=============================================");
    }

    static void ShowMainMenu(ProductManager productManager)
    {
        while (true)
        {
            ShowHeader();
            productManager.ShowProducts();

            Console.WriteLine("\nMenu Utama:");
            Console.WriteLine("1. Tambah Produk");
            Console.WriteLine("2. Hapus Produk");
            Console.WriteLine("3. Cari Produk");
            Console.WriteLine("4. Sortir Produk");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    ShowHeader();
                    productManager.ShowProducts();
                    productManager.AddProduct();
                    ShowContinueOptions(productManager);
                    break;
                case "2":
                    ShowHeader();
                    productManager.ShowProducts();
                    productManager.DeleteProduct();
                    ShowContinueOptions(productManager);
                    break;
                case "3":
                    ShowHeader();
                    productManager.ShowProducts();
                    productManager.SearchProduct();
                    ShowContinueOptions(productManager);
                    break;
                case "4":
                    ShowHeader();
                    productManager.ShowProducts();
                    productManager.SortProduct();
                    ShowContinueOptions(productManager);
                    break;
                case "5":
                    ShowHeader();
                    return;
                default:
                    ShowHeader();
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }

    static void ShowContinueOptions(ProductManager productManager)
    {
        Console.WriteLine("\n1. Lanjutkan");
        Console.WriteLine("2. Keluar");
        Console.Write("Pilih opsi: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Clear();
                break;
            case "2":
                Console.Clear();
                ShowHeader();
                Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                break;
        }
    }
}