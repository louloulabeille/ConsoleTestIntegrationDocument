using System;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using OpenXmlHelpers.Word;
using DefautAfpaBriveContext;
using AfpaBrive;
using System.Linq;

namespace ConsoleTestIntegrationDocument
{
    class Program
    {
        private static DefaultContext _context = new DefaultContext();
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"\Document\TestConvention.docx";
            if (File.Exists(path))
            {
                string pathCopy = Directory.GetCurrentDirectory() + @"\Document\Copy.docx";
                File.Copy(path, pathCopy);
                //using (WordprocessingDocument doc = WordprocessingDocument.Open(path, true))
                //{

                //}
                if (!File.Exists(pathCopy))
                    return;
                using (WordprocessingDocument doc = WordprocessingDocument.Open(pathCopy, true))
                {
                    IEnumerable<FieldCode> docWorld = OpenXmlWordHelpers.GetMergeFields(doc);
                    Entreprise ent = Program._context.Entreprises.First();
                    foreach(FieldCode item in docWorld)
                    {
                        if (item.InnerXml.Contains("Nom_Entreprise"))
                        {
                            item.ReplaceWithText(ent.RaisonSociale);
                        }

                        if (item.InnerXml.Contains("Adresse_entreprise"))
                        {
                            item.ReplaceWithText(ent.NumeroNomVoieEntreprise);
                        }

                        //if (item.InnerXml.Contains("Adresse_entreprise_suite"))
                        //{
                        //    if (ent.ComplementAdresseEntreprise == string.Empty)
                        //        item.ReplaceWithText("0");
                        //    else
                        //        item.ReplaceWithText(ent.ComplementAdresseEntreprise);
                        //}

                        if (item.InnerXml.Contains("Code_postal_entreprise"))
                        {
                            item.ReplaceWithText(ent.CodePostalEntreprise);
                        }

                        if (item.InnerXml.Contains("Ville_entreprise"))
                        {
                            item.ReplaceWithText(ent.VilleEntreprise);
                        }

                        if (item.InnerXml.Contains("Téléphone_entreprise"))
                        {
                            item.ReplaceWithText("");
                        }
                    }
                }
                    
            }
        }


    }
}
