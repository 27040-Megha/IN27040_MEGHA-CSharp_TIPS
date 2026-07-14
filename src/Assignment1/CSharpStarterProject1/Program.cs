namespace ContactManager
{
    internal class Program
    {


        static void addContact(List<List<string>> contacts)
        {
            List<string> contact = new List<string>();
            Console.WriteLine("Enter Name: ");
            contact.Add(Console.ReadLine());
            Console.WriteLine("Enter Phone Number: ");
            string phnNumber = Console.ReadLine();
            while (!(long.TryParse(phnNumber, out long result)))
            {
                Console.WriteLine("Number not valid - Give valid number");
                phnNumber = Console.ReadLine();
            }
            contact.Add(phnNumber);
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            while (!(email.Contains('@') && email.Contains('.')))
            {
                Console.WriteLine("Not Valid email. Give valid email with '@' and '.' included");
                email = Console.ReadLine();
            }
            contact.Add(email);
            Console.WriteLine("Enter Description(Place/Relation/Profession): ");
            contact.Add(Console.ReadLine());
            contacts.Add(contact);
            Console.WriteLine("Contact Added Successfully");
            Console.WriteLine("---------------------------------------------");
        }

        static void viewContactList(List<List<string>> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Saved in Contact List\n");
                return;
            }
            List<String> contactListOnlyNames = new List<string>();
            foreach (var contact in contacts)
            {
                contactListOnlyNames.Add(contact[0]);
            }
            contactListOnlyNames.Sort();
            foreach (var names in contactListOnlyNames)
            {
                Console.WriteLine(names);
            }
            Console.WriteLine("---------------------------------------------");
        }

        static void editContact(List<List<string>> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Saved in Contact List to be editted\n");
                return;
            }
            Console.WriteLine("Enter Contact Name to be editted:");
            string name = Console.ReadLine();
            foreach (List<string> contact in contacts)
            {
                if (contact.Contains(name))
                {
                    Console.WriteLine("Do you want to edit Name([Y]es/[N]o)? : ");
                    char ch = char.Parse(Console.ReadLine());
                    if (ch == 'y' || ch == 'Y')
                    {
                        Console.WriteLine("New Name : ");
                        contact[0] = Console.ReadLine();
                    }
                    Console.WriteLine("Do you want to edit Phone Number([Y]es/[N]o)? : ");
                    ch = char.Parse(Console.ReadLine());
                    if (ch == 'y' || ch == 'Y')
                    {
                        Console.WriteLine("New Phone Number : ");
                        contact[1] = Console.ReadLine();
                    }
                    Console.WriteLine("Do you want to edit Email([Y]es/[N]o)? : ");
                    ch = char.Parse(Console.ReadLine());
                    if (ch == 'y' || ch == 'Y')
                    {
                        Console.WriteLine("New Email : ");
                        contact[2] = Console.ReadLine();
                    }
                    Console.WriteLine("Do you want to edit Description([Y]es/[N]o)? : ");
                    ch = char.Parse(Console.ReadLine());
                    if (ch == 'y' || ch == 'Y')
                    {
                        Console.WriteLine("New Description : ");
                        contact[3] = Console.ReadLine();
                    }
                    Console.WriteLine("Contact Editted Successfully");
                    Console.WriteLine("---------------------------------------------");
                    return;
                }
            }
            Console.WriteLine("No contact found with that name. Create new Contact");
        }

        static void deleteContact(List<List<string>> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Saved in Contact List to be deleted\n");
                return;
            }
            Console.WriteLine("Enter Name or phone number to be deleted from Contacts List");
            string toBeDeleted = Console.ReadLine();
            for (int i = 0; i < contacts.Count; i++)
            {
                List<string> contact = contacts[i];
                if (contact.Contains(toBeDeleted))
                {
                    contacts.RemoveAt(i);
                    Console.WriteLine("Contact Deleted Successfully");
                    Console.WriteLine("---------------------------------------------");
                    return;
                }
            }
        }

        static void searchForContact(List<List<string>> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Saved in Contact List to be Searched\n");
                return;
            }
            Console.WriteLine("Type name/phn number to be searched: ");
            string name = Console.ReadLine();
            foreach (List<string> contact in contacts)
            {
                if (contact.Contains(name))
                {
                    Console.WriteLine("Name         : " + contact[0]);
                    Console.WriteLine("Phone Number : " + contact[1]);
                    Console.WriteLine("Email        : " + contact[2]);
                    Console.WriteLine("Description  : " + contact[3]);
                    Console.WriteLine("---------------------------------------------");
                    return;
                }
            }
            Console.WriteLine("The contact you are searching for is not found");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Basic Contact Manager Console Application");
            Console.WriteLine("---------------------------------------------");
            char ch;
            List<List<string>> contacts = new List<List<string>>();
            do
            {
                Console.WriteLine("What do you want to do now?");
                Console.WriteLine("1.[A]dd Contact");
                Console.WriteLine("2.[V]iew Contact List");
                Console.WriteLine("3.[E]dit Contact");
                Console.WriteLine("4.[D]elete Contact");
                Console.WriteLine("5.[S]earch Contact");
                Console.WriteLine("6.[C]lose Application");
                ch = char.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 'A':
                    case 'a':
                        addContact(contacts);
                        break;
                    case 'V':
                    case 'v':
                        viewContactList(contacts);
                        break;
                    case 'E':
                    case 'e':
                        editContact(contacts);
                        break;
                    case 'D':
                    case 'd':
                        deleteContact(contacts);
                        break;
                    case 'S':
                    case 's':
                        searchForContact(contacts);
                        break;
                    default:
                        break;
                }

            } while (!(ch == 'C' || ch == 'c'));

        }
    }
}