using Real_estate_Nyckelpigan.Models;


namespace Real_estate_Nyckelpigan.Services
{
    internal class MenuService
    {
        //Create new Case
        public static async Task CreateCaseAsync()
        {
            var CreateRenterAndAddress = new CreateCase();

            Console.Write("Förnamn på hyresgäst: ");
            CreateRenterAndAddress.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn på hyresgäst: ");
            CreateRenterAndAddress.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress på hyresgäst: ");
            CreateRenterAndAddress.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer på hyresgäst: ");
            CreateRenterAndAddress.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Gatuadress på hyresgäst: ");
            CreateRenterAndAddress.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postnummer på hyresgäst: ");
            CreateRenterAndAddress.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad på hyresgäst: ");
            CreateRenterAndAddress.City = Console.ReadLine() ?? "";

            Console.Write("Skapa internt ärendenummer för ärendet: ");
            CreateRenterAndAddress.InternalCaseId = Console.ReadLine() ?? "";

            Console.Write("Beskriv ärendet/felanmälan: ");
            CreateRenterAndAddress.Description = Console.ReadLine() ?? "";

            Console.Write("Skriv in datum för skapat ärende/felanmälan: ");
            CreateRenterAndAddress.IncomingDate = Console.ReadLine() ?? "";

            Console.Write("Skriv in status på ärende/felanmälan: Ej påbörjat, Påbörjat, Avslutat: ");
            CreateRenterAndAddress.Status = Console.ReadLine() ?? "";

            await CaseService.SaveAsync(CreateRenterAndAddress);
        }


        public static async Task ListAllCasesAsync()
        {
            //get all Cases from database
            var renters = await CaseService.GetAllAsync();

            if (renters.Any())
            {
                foreach (CreateCase _case in renters)
                {
                    Console.WriteLine($"Hyresgästnummer på hyresgäst som felanmälde: {_case.Id}");
                    Console.WriteLine($"Internt ärendenummer: {_case.InternalCaseId}");
                    Console.WriteLine($"Beskrivning ärende: {_case.Description}");
                    Console.WriteLine($"Status ärende: {_case.Status}");
                    Console.WriteLine($"Inkommet datum på ärende: {_case.IncomingDate}");
                    Console.WriteLine($"Kommentar till ärende: {_case.PropertyManagerComment}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga aktuella ärenden finns i databasen");
                Console.WriteLine("");
            }
        }


        public static async Task ListSpecificCaseAsync()
        {
            //get specific Case from database
            Console.WriteLine("Ange internt ärendenummer på ärende: ");
            var internalcaseid = Console.ReadLine();

            if (!string.IsNullOrEmpty(internalcaseid))
            {
                var _case = await CaseService.GetAsync(internalcaseid);

                if (_case != null)
                {
                    Console.WriteLine($"Hyresgästnummer på hyresgäst som felanmälde: {_case.Id}");
                    Console.WriteLine($"Internt ärendenummer: {_case.InternalCaseId}");
                    Console.WriteLine($"Beskrivning ärende: {_case.Description}");
                    Console.WriteLine($"Status ärende: {_case.Status}");
                    Console.WriteLine($"Inkommet datum på ärende: {_case.IncomingDate}");
                    Console.WriteLine($"Kommentar till ärende: {_case.PropertyManagerComment}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen ärende med den angivna ärendenummer {internalcaseid} hittades. ");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Ingen ärendenummer angiven.");
                Console.WriteLine("");
            }
        }


        public static async Task UpdateSpecificCaseAsync()
        {
            //update specific Case from database
            Console.WriteLine("Ange internt ärendenummer på ärende: ");
            var internalcaseid = Console.ReadLine();

            if (!string.IsNullOrEmpty(internalcaseid))
            {
                var _case = await CaseService.GetAsync(internalcaseid);
                if (_case != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Ändra status på ärenden eller lägg till en kommentar \n");
                    Console.Write("Skriv in nya ärende statusen: Ej påbörjat, Påbörjat eller Avslutat:");
                    _case.Status = Console.ReadLine() ?? null!;

                    Console.Write("Skriv in en kommentar för ärendet: ");
                    _case.PropertyManagerComment = Console.ReadLine() ?? null!;

                    //update specific Case from database
                    await CaseService.UpdateAsync(_case);
                }
                else
                {
                    Console.WriteLine($"Ingen ärende med den angivna ärendenummer {internalcaseid} hittades.");
                    Console.WriteLine("");
                }
            }

            else
            {
                Console.WriteLine($"Ingen ärendenummer angiven.");
                Console.WriteLine("");
            }
        }


        public static async Task DeleteSpecificCaseAsync()
        {
            //delete specific Case from database
            Console.WriteLine("Ange ärendenummer på ärende: ");
            var internalcaseid = Console.ReadLine();

            if (!string.IsNullOrEmpty(internalcaseid))
            {
                await CaseService.DeleteAsync(internalcaseid);
                Console.WriteLine("Glöm inte uppdatera/refresh databasen efter du tagit bort ett ärende");
            }
            else
            {
                Console.WriteLine($"Ingen ärendenummer angiven.");
                Console.WriteLine("");
            }
        }

        public static async Task ListAllCasesAndRentersAsync()
        {
            //get all Cases from database
            var renters = await CaseService.GetCaseRenterAsync();

            if (renters.Any())
            {
                Console.WriteLine($"Nedan är information på hyresgästen och vilket ärendenummer som är kopplat till hyresgästen:");
                Console.WriteLine("");
                foreach (CreateCase _case in renters)
                {
   
                    Console.WriteLine($"Hyresgäst ID: {_case.Id}");
                    Console.WriteLine($"Namn: {_case.FirstName} {_case.LastName}");
                    Console.WriteLine($"Email: {_case.Email}");
                    Console.WriteLine($"Tel: {_case.PhoneNumber}");
                    Console.WriteLine($"Adressen: {_case.StreetName}");
                    Console.WriteLine($"Stad: {_case.PostalCode}, {_case.City}");
                    Console.WriteLine($"Ärende ID i databasen: {_case.CaseId}");
                    Console.WriteLine($"Internt ärendenummer: {_case.InternalCaseId}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga aktuella hyresgäster med ärenden finns i databasen");
                Console.WriteLine("");
            }
        }

    }
}
