using System.Xml.Linq;

namespace ExerciceXDocument
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load(@"C:\Users\abots\source\repos\ExerciceXDocument\fichier.xml");
            var personne = new Personne();

            if (doc.Root is not null)
            {
                foreach (var item in doc.Root.Elements())
                {
                    if (item.Name=="Nom")
                    {
                        personne.Nom=item.Value;
                    }
                    else if (item.Name=="Prenom")
                    {
                        personne.Prenom=item.Value;
                    }
                    else if (item.Name=="DateDeNaissance")
                    {
                        personne.DateDeNaissance= DateTime.Parse(item.Value);
                    }
                    else if (item.Name=="Taille")
                    {
                        personne.Taille=int.Parse(item.Value);
                    }
                }
            }

            Console.WriteLine($"{personne.Nom} {personne.Prenom} {personne.DateDeNaissance} {personne.Taille}");

            var address = new XElement("Adress", "487 rue de neuchatel");

            if (doc.Root is not null)
            {
                var recupElement = doc.Root.Element("Taille");
                if(recupElement is not null)
                {
                    recupElement.AddAfterSelf(address);
                }
            }
            Console.WriteLine(doc.ToString());
        }
    }
}
