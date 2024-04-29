public class ProductManager
{
    private List<Product> products = new List<Product>
    {
        new Product("Ayam Goreng", 15000, 50),
        new Product("Burger", 20000, 30),
        new Product("Nasi Box", 25000, 40),
        new Product("Soft Drink", 10000, 100),
        new Product("French Fries", 12000, 60)
    };

    public void ShowProducts()
    {
        Console.WriteLine("\nDaftar Produk:");
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine("| No  |    Nama       |         Harga          |       Stok       |");
        Console.WriteLine("-------------------------------------------------------------------");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"| {i + 1,-3} | {products[i].Name,-13} | {products[i].Price.ToString("C2"),-22} | {products[i].Stock,-16} |");
        }
        Console.WriteLine("-------------------------------------------------------------------");
    }

    public void AddProduct()
    {
        Console.WriteLine("== Tambah Produk ==");
        Console.WriteLine("Masukkan nama produk:");
        string name = Console.ReadLine();

        Console.WriteLine("Masukkan harga produk:");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Masukkan jumlah stok produk:");
        int stock = Convert.ToInt32(Console.ReadLine());

        products.Add(new Product(name, price, stock));
        Console.WriteLine("Produk berhasil ditambahkan.");
    }

    public void DeleteProduct()
    {
        Console.WriteLine("== Hapus Produk ==");
        Console.WriteLine("Masukkan nama produk yang akan dihapus:");
        string name = Console.ReadLine();

        Product productToDelete = products.Find(p => p.Name.ToLower() == name.ToLower());

        if (productToDelete != null)
        {
            products.Remove(productToDelete);
            Console.WriteLine("Produk berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("Produk tidak ditemukan.");
        }
    }

    public void SearchProduct()
    {
        Console.WriteLine("== Cari Produk ==");
        Console.WriteLine("Pilih opsi pencarian:");
        Console.WriteLine("1. Berdasarkan nama");
        Console.WriteLine("2. Berdasarkan range harga");
        Console.Write("Pilih opsi: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.WriteLine("Masukkan nama produk yang akan dicari:");
                string name = Console.ReadLine();
                Product productByName = products.Find(p => p.Name.ToLower() == name.ToLower());
                if (productByName != null)
                {
                    Console.WriteLine($"Nama: {productByName.Name}, Harga: {productByName.Price}, Stok: {productByName.Stock}");
                }
                else
                {
                    Console.WriteLine("Produk tidak ditemukan.");
                }
                break;
            case "2":
                Console.WriteLine("Masukkan rentang harga (misal: 5000-10000):");
                string[] priceRange = Console.ReadLine().Split('-');
                double minPrice = Convert.ToDouble(priceRange[0]);
                double maxPrice = Convert.ToDouble(priceRange[1]);
                var productsInRange = products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);
                if (productsInRange.Count > 0)
                {
                    Console.WriteLine("Produk dalam rentang harga tersebut:");
                    foreach (var product in productsInRange)
                    {
                        Console.WriteLine(product.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Tidak ada produk dalam rentang harga tersebut.");
                }
                break;
            default:
                Console.WriteLine("Opsi tidak valid.");
                break;
        }
    }

    public void SortProduct()
    {
        Console.WriteLine("== Sortir Produk ==");
        Console.WriteLine("Pilih opsi pengurutan:");
        Console.WriteLine("1. Ascending (Stok terendah ke tertinggi)");
        Console.WriteLine("2. Descending (Stok tertinggi ke terendah)");
        Console.Write("Pilihan: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                products.Sort((p1, p2) => p1.Stock.CompareTo(p2.Stock));
                Console.WriteLine("Produk berhasil disortir secara ascending berdasarkan jumlah stok.");
                break;
            case "2":
                products.Sort((p1, p2) => p2.Stock.CompareTo(p1.Stock));
                Console.WriteLine("Produk berhasil disortir secara descending berdasarkan jumlah stok.");
                break;
            default:
                Console.WriteLine("Opsi tidak valid.");
                break;
        }
    }
}