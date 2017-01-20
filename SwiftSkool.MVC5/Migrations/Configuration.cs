namespace SwiftSkool.MVC5.Migrations
{
    using Entities;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolDb ctx)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if(!ctx.Classes.Any())
            {
                var jss1a = new Class("JSS", "1", "A");
                var jss1b = new Class("JSS", "1", "B");
                var jss1c = new Class("JSS", "1", "C");
                var jss2A = new Class("JSS", "2", "A");
                var jss2B = new Class("JSS", "2", "B");
                var jss2C = new Class("JSS", "2", "C");
                var jss3A = new Class("JSS", "3", "A");
                var jss3B = new Class("JSS", "3", "B");
                var jss3C = new Class("JSS", "3", "C");
                var SS1A = new Class("SSS", "1", "A");
                var SS1B = new Class("SSS", "1", "B");
                var SS1C = new Class("SSS", "1", "C");
                var SS2A = new Class("SSS", "2", "A");
                var SS2B = new Class("SSS", "2", "B");
                var SS2C = new Class("SSS", "2", "C");
                var SS3A = new Class("SSS", "3", "A");
                var SS3B = new Class("SSS", "3", "B");
                var SS3C = new Class("SSS", "3", "C");

                ctx.Classes.AddOrUpdate(jss1a);
                ctx.Classes.AddOrUpdate(jss1b);
                ctx.Classes.AddOrUpdate(jss1c);
                ctx.Classes.AddOrUpdate(jss2A);
                ctx.Classes.AddOrUpdate(jss2B);
                ctx.Classes.AddOrUpdate(jss2C);
                ctx.Classes.AddOrUpdate(jss3A);
                ctx.Classes.AddOrUpdate(jss3B);
                ctx.Classes.AddOrUpdate(jss3C);
                ctx.Classes.AddOrUpdate(SS1A);
                ctx.Classes.AddOrUpdate(SS1B);
                ctx.Classes.AddOrUpdate(SS1C);
                ctx.Classes.AddOrUpdate(SS2A);
                ctx.Classes.AddOrUpdate(SS2B);
                ctx.Classes.AddOrUpdate(SS2C);
                ctx.Classes.AddOrUpdate(SS3A);
                ctx.Classes.AddOrUpdate(SS3B);
                ctx.Classes.AddOrUpdate(SS3C);

                ctx.SaveChanges();
            }

            if (!ctx.States.Any())
            {
                var abiaState = new State
                {
                    Name = "Abia State",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Aba North"
                        },
                         new LocalGovernment
                        {
                            Name ="Aba South"
                        },
                         new LocalGovernment
                        {
                            Name ="Arochukwu"
                        },
                         new LocalGovernment
                        {
                            Name ="Bende"
                        },
                         new LocalGovernment
                        {
                            Name ="Ikwuano"
                        },
                         new LocalGovernment
                        {
                            Name ="Isiala Ngwa North"
                        },
                         new LocalGovernment
                        {
                            Name ="Isiala Ngwa South"
                        },
                         new LocalGovernment
                        {
                            Name ="Isiukwuato"
                        },
                         new LocalGovernment
                        {
                            Name ="Obi Ngwa"
                        },
                         new LocalGovernment
                        {
                            Name ="Ohafia"
                        },
                         new LocalGovernment
                        {
                            Name ="Osisioma Ngwa"
                        },
                         new LocalGovernment
                        {
                            Name ="Ugwunagbo"
                        },
                         new LocalGovernment
                        {
                            Name ="Ukwa East"
                        },
                         new LocalGovernment
                        {
                            Name ="Ukwa West"
                        },
                         new LocalGovernment
                        {
                            Name ="Umuahia North"
                        },
                         new LocalGovernment
                        {
                            Name ="Umuahia South"
                        },
                         new LocalGovernment
                        {
                            Name ="Umunneochi"
                        }
                    }
                };

                var adamawa = new State
                {
                    Name = "Adamawa ",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Demsa"
                        },
                         new LocalGovernment
                        {
                            Name ="Fufore"
                        },
                          new LocalGovernment
                        {
                            Name ="Ganaye"
                        },
                         new LocalGovernment
                        {
                            Name ="Gireri"
                        },
                          new LocalGovernment
                        {
                            Name ="Gombi"
                        },
                           new LocalGovernment
                        {
                            Name ="Guyuk"
                        },
                            new LocalGovernment
                        {
                            Name ="Hong"
                        },
                         new LocalGovernment
                        {
                            Name ="Jada"
                        },
                          new LocalGovernment
                        {
                            Name ="Lamurde"
                        },
                           new LocalGovernment
                        {
                            Name ="Madagali"
                        },
                            new LocalGovernment
                        {
                            Name ="Maiha"
                        },
                             new LocalGovernment
                        {
                            Name ="Mayo Belwa"
                        },
                              new LocalGovernment
                        {
                            Name ="Michika"
                        },
                               new LocalGovernment
                        {
                            Name ="Mubi North"
                        },
                                new LocalGovernment
                        {
                            Name ="Mubi South"
                        },
                                 new LocalGovernment
                        {
                            Name ="Numan"
                        },
                                  new LocalGovernment
                        {
                            Name ="Shelleng"
                        },
                                   new LocalGovernment
                        {
                            Name ="Song"
                        },
                                    new LocalGovernment
                        {
                            Name ="Toungo"
                        }
                    }
                };

                var akwaIbom = new State
                {
                    Name = "Akwa Ibom",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Abak"
                        },
                        new LocalGovernment
                        {
                            Name ="Eastern Obolo"
                        },
                        new LocalGovernment
                        {
                            Name ="Eket"
                        },
                        new LocalGovernment
                        {
                            Name ="Esit Eket"
                        },
                        new LocalGovernment
                        {
                            Name ="Essien Udim"
                        },
                        new LocalGovernment
                        {
                            Name ="Etim Ekpo"
                        },
                        new LocalGovernment
                        {
                            Name ="Etinan"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibeno"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibesikpo Asutan"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibiono Ibom"
                        },
                        new LocalGovernment
                        {
                            Name ="Ika"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikono"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikot Abasi"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikot Ekpene"
                        },
                        new LocalGovernment
                        {
                            Name ="Ini"
                        },
                        new LocalGovernment
                        {
                            Name ="Itu"
                        },
                        new LocalGovernment
                        {
                            Name ="Mbo"
                        },
                        new LocalGovernment
                        {
                            Name ="Mkpat Enin"
                        },
                        new LocalGovernment
                        {
                            Name ="Nsit Atai"
                        },
                        new LocalGovernment
                        {
                            Name ="Nsit Ibom"
                        },
                        new LocalGovernment
                        {
                            Name ="Nsit Ubium"
                        },
                        new LocalGovernment
                        {
                            Name ="Obot Akara"
                        },
                        new LocalGovernment
                        {
                            Name ="Okobo"
                        },
                        new LocalGovernment
                        {
                            Name ="Onna"
                        },
                        new LocalGovernment
                        {
                            Name ="Oron"
                        },
                        new LocalGovernment
                        {
                            Name ="Oruk Anam"
                        },
                        new LocalGovernment
                        {
                            Name ="Udung Uko"
                        },
                        new LocalGovernment
                        {
                            Name ="Ukanafun"
                        },
                        new LocalGovernment
                        {
                            Name ="Uruan"
                        },
                        new LocalGovernment
                        {
                            Name ="Urue Offong/Oruko"
                        },
                        new LocalGovernment
                        {
                            Name ="Uyo"
                        }
                    }
                };

                var anambra = new State
                {
                    Name = "Anambra",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Anambra East "
                        },
                        new LocalGovernment
                        {
                            Name ="Anambra West"
                        },
                        new LocalGovernment
                        {
                            Name ="Anaocha"
                        },
                        new LocalGovernment
                        {
                            Name ="Awka North"
                        },
                        new LocalGovernment
                        {
                            Name ="Ayamelum"
                        },
                        new LocalGovernment
                        {
                            Name ="Dunukofia"
                        },
                        new LocalGovernment
                        {
                            Name ="Ekwusigo"
                        },
                        new LocalGovernment
                        {
                            Name ="Idemili North"
                        },
                        new LocalGovernment
                        {
                            Name ="Idemili Nouth"
                        },
                        new LocalGovernment
                        {
                            Name ="Ihiala"
                        },
                        new LocalGovernment
                        {
                            Name ="Njikoka"
                        },
                        new LocalGovernment
                        {
                            Name ="Nnewi North"
                        },
                        new LocalGovernment
                        {
                            Name ="Nnewi North"
                        },
                        new LocalGovernment
                        {
                            Name ="Nnewi South"
                        },
                        new LocalGovernment
                        {
                            Name ="Ogbaru"
                        },
                        new LocalGovernment
                        {
                            Name ="Onitsha North"
                        },
                        new LocalGovernment
                        {
                            Name ="Onitsha South"
                        },
                        new LocalGovernment
                        {
                            Name ="Orumba North"
                        },
                         new LocalGovernment
                        {
                            Name ="Orumba South"
                        },

                        new LocalGovernment
                        {
                            Name ="Oyi"
                        },

                  },
                };

                var bauchi = new State
                {
                    Name = "Bauchi",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Bauchi"
                        },
                        new LocalGovernment
                        {
                            Name ="Bogoro"
                        },
                        new LocalGovernment
                        {
                            Name ="Damban"
                        },
                        new LocalGovernment
                        {
                            Name ="Darazo"
                        },
                        new LocalGovernment
                        {
                            Name ="Dass"
                        },
                        new LocalGovernment
                        {
                            Name ="Ganjuwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Giade"
                        },
                        new LocalGovernment
                        {
                            Name ="Itas/Gadau"
                        },
                        new LocalGovernment
                        {
                            Name ="Jama’are"
                        },
                        new LocalGovernment
                        {
                            Name ="Katagum"
                        },
                        new LocalGovernment
                        {
                            Name ="Kirfi"
                        },
                        new LocalGovernment
                        {
                            Name ="Misau"
                        },
                        new LocalGovernment
                        {
                            Name ="Ningi"
                        },
                        new LocalGovernment
                        {
                            Name ="Shira"
                        },
                        new LocalGovernment
                        {
                            Name ="Tafawa Balewa"
                        },
                        new LocalGovernment
                        {
                            Name ="Toro"
                        },
                        new LocalGovernment
                        {
                            Name ="Warji"
                        },
                         new LocalGovernment
                        {
                            Name ="Zaki"
                        }
                    }
                };


                var bayelsa = new State
                {
                    Name = "Bayelsa",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Brass"
                        },
                         new LocalGovernment
                        {
                            Name ="Ekeremor"
                        },
                          new LocalGovernment
                        {
                            Name ="Kolokuma/Opokuma"
                        },
                           new LocalGovernment
                        {
                            Name ="Nembe"
                        },
                            new LocalGovernment
                        {
                            Name ="Ogbia"
                        },
                             new LocalGovernment
                        {
                            Name ="Sagbama"
                        },
                              new LocalGovernment
                        {
                            Name ="Southern Jaw"
                        },
                               new LocalGovernment
                        {
                            Name ="Yenegoa"
                        }
                    }
                };

                var benue = new State
                {
                    Name = "Benue",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Ado"
                        },
                         new LocalGovernment
                        {
                            Name ="Agatu"
                        },
                          new LocalGovernment
                        {
                            Name ="Apa"
                        },
                           new LocalGovernment
                        {
                            Name ="Buruku"
                        },
                            new LocalGovernment
                        {
                            Name ="Gboko"
                        },
                             new LocalGovernment
                        {
                            Name ="Guma"
                        },
                              new LocalGovernment
                        {
                            Name ="Gwer East"
                        },
                               new LocalGovernment
                        {
                            Name ="Gwer West"
                        },
                                new LocalGovernment
                        {
                            Name ="Katsina Ala"
                        },
                                 new LocalGovernment
                        {
                            Name ="Konshisha"
                        },
                                  new LocalGovernment
                        {
                            Name ="Kwande"
                        },
                                   new LocalGovernment
                        {
                            Name ="Logo"
                        },
                                    new LocalGovernment
                        {
                            Name ="Makurdi"
                        },
                                     new LocalGovernment
                        {
                            Name ="Obi"
                        },
                                      new LocalGovernment
                        {
                            Name ="Ogbadibo"
                        },
                                       new LocalGovernment
                        {
                            Name ="Oju"
                        },
                                        new LocalGovernment
                        {
                            Name ="Okpokwu"
                        },
                                         new LocalGovernment
                        {
                            Name ="Ohimini"
                        },
                                          new LocalGovernment
                        {
                            Name ="Oturkpo"
                        },
                                           new LocalGovernment
                        {
                            Name ="Tarka"
                        },
                                            new LocalGovernment
                        {
                            Name ="Ukum"
                        },
                                             new LocalGovernment
                        {
                            Name ="Ushongo"
                        },
                                              new LocalGovernment
                        {
                            Name ="Vandeikya"
                        }
                    }
                };

                var borno = new State
                {
                    Name = "Borno",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Askira/Uba"
                        },
                        new LocalGovernment
                        {
                            Name ="Bama"
                        },
                        new LocalGovernment
                        {
                            Name ="Bayo"
                        },
                        new LocalGovernment
                        {
                            Name ="Biu"
                        },
                        new LocalGovernment
                        {
                            Name ="Chibok"
                        },
                        new LocalGovernment
                        {
                            Name ="Damboa"
                        },
                        new LocalGovernment
                        {
                            Name ="Dikwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Gubio"
                        },
                        new LocalGovernment
                        {
                            Name ="Guzamala"
                        },
                        new LocalGovernment
                        {
                            Name ="Gwoza"
                        },
                        new LocalGovernment
                        {
                            Name ="Hawul"
                        },
                        new LocalGovernment
                        {
                            Name ="Jere"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaga"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaga"
                        },
                        new LocalGovernment
                        {
                            Name ="Kala/Balge"
                        },
                        new LocalGovernment
                        {
                            Name ="Konduga"
                        },
                        new LocalGovernment
                        {
                            Name ="Kukawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Kwaya Kusar"
                        },
                        new LocalGovernment
                        {
                            Name ="Mafa"
                        },
                        new LocalGovernment
                        {
                            Name ="Magumeri"
                        },
                        new LocalGovernment
                        {
                            Name ="Maiduguri"
                        },
                        new LocalGovernment
                        {
                            Name ="Marte"
                        },
                        new LocalGovernment
                        {
                            Name ="Mobbar"
                        },
                        new LocalGovernment
                        {
                            Name ="Monguno"
                        },
                        new LocalGovernment
                        {
                            Name ="Ngala"
                        },
                        new LocalGovernment
                        {
                            Name ="Nganzai"
                        },
                         new LocalGovernment
                        {
                            Name ="Shani"
                        }
                    }
                };

                var crossRiver = new State
                {
                    Name = "Cross River ",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Odukpani"
                        },
                       new LocalGovernment
                        {
                            Name ="Akamkpa"
                        },
                       new LocalGovernment
                        {
                            Name ="Biase"
                        },
                       new LocalGovernment
                        {
                            Name ="Abi"
                        },
                       new LocalGovernment
                        {
                            Name ="Ikom"
                        },
                       new LocalGovernment
                        {
                            Name ="Yarkur"
                        },
                       new LocalGovernment
                        {
                            Name ="Odubra"
                        },
                       new LocalGovernment
                        {
                            Name ="Boki"
                        },
                       new LocalGovernment
                        {
                            Name ="Ogoja"
                        },
                       new LocalGovernment
                        {
                            Name ="Yala"
                        },
                       new LocalGovernment
                        {
                            Name ="Obanliku"
                        },
                       new LocalGovernment
                        {
                            Name ="Obudu"
                        },
                       new LocalGovernment
                        {
                            Name ="Calabar South"
                        },
                       new LocalGovernment
                        {
                            Name ="Etung"
                        },
                       new LocalGovernment
                        {
                            Name ="Bekwara"
                        },
                       new LocalGovernment
                        {
                            Name ="Bakassi"
                        },
                       new LocalGovernment
                        {
                            Name ="Calabar Municipality"
                        }
                    }
                };
                var delta = new State
                {
                    Name = "Delta",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Oshimili"
                        },
                         new LocalGovernment
                        {
                            Name ="Aniocha"
                        },
                          new LocalGovernment
                        {
                            Name ="Aniocha South"
                        },
                           new LocalGovernment
                        {
                            Name ="Ika South"
                        },
                            new LocalGovernment
                        {
                            Name ="Ika North East"
                        },
                             new LocalGovernment
                        {
                            Name ="Ndokwa West"
                        },
                              new LocalGovernment
                        {
                            Name ="Isoko south"
                        },
                               new LocalGovernment
                        {
                            Name ="Isoko North"
                        },
                                new LocalGovernment
                        {
                            Name ="Bomadi"
                        },
                                 new LocalGovernment
                        {
                            Name ="Burutu"
                        },
                                  new LocalGovernment
                        {
                            Name ="Ughelli South"
                        },
                                   new LocalGovernment
                        {
                            Name ="Ughelli North"
                        },
                                    new LocalGovernment
                        {
                            Name ="Ethiope West"
                        },
                                     new LocalGovernment
                        {
                            Name ="Ethiope East"
                        },
                                      new LocalGovernment
                        {
                            Name ="Sapele"
                        },
                                       new LocalGovernment
                        {
                            Name ="Okpe"
                        },
                                        new LocalGovernment
                        {
                            Name ="Warri North"
                        },
                                         new LocalGovernment
                        {
                            Name ="Warri South"
                        },
                                          new LocalGovernment
                        {
                            Name ="Uvwie"
                        },
                                           new LocalGovernment
                        {
                            Name ="Oshimili North"
                        },
                                            new LocalGovernment
                        {
                            Name ="Patani"
                        }
                    }
                };

                var ebonyi = new State
                {
                    Name = "Ebonyi",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Afikpo South"
                        },
                         new LocalGovernment
                        {
                            Name ="Afikpo North"
                        },
                          new LocalGovernment
                        {
                            Name ="Onicha"
                        },
                           new LocalGovernment
                        {
                            Name ="Ohaozara"
                        },
                            new LocalGovernment
                        {
                            Name ="Abakaliki"
                        },
                             new LocalGovernment
                        {
                            Name ="Ishielu"
                        },
                              new LocalGovernment
                        {
                            Name ="lkwo"
                        },
                               new LocalGovernment
                        {
                            Name ="Ezza"
                        },
                                new LocalGovernment
                        {
                            Name ="Ezza South"
                        },
                                 new LocalGovernment
                        {
                            Name ="Ohaukwu"
                        },
                                  new LocalGovernment
                        {
                            Name ="Ebonyi"
                        },
                                     new LocalGovernment
                        {
                            Name ="Ivo"
                        }
                    }
                };

                var edo = new State
                {
                    Name = "Edo ",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Esan North East"
                        },
                        new LocalGovernment
                        {
                            Name ="Esan Central"
                        },
                        new LocalGovernment
                        {
                            Name ="Esan West"
                        },
                        new LocalGovernment
                        {
                            Name ="Egor"
                        },
                        new LocalGovernment
                        {
                            Name ="Ukpoba"
                        },
                        new LocalGovernment
                        {
                            Name ="Central"
                        },
                        new LocalGovernment
                        {
                            Name ="Etsako Central"
                        },
                        new LocalGovernment
                        {
                            Name ="Igueben"
                        },
                        new LocalGovernment
                        {
                            Name ="Oredo"
                        },
                        new LocalGovernment
                        {
                            Name ="Ovia South West"
                        },
                        new LocalGovernment
                        {
                            Name ="Ovia South East"
                        },
                        new LocalGovernment
                        {
                            Name ="Orhionwon"
                        },
                        new LocalGovernment
                        {
                            Name ="Uhunmwonde"
                        },
                        new LocalGovernment
                        {
                            Name ="Etsako East"
                        },
                        new LocalGovernment
                        {
                            Name ="Esan South East"
                        }
                    }
                };

                var ekiti = new State
                {
                    Name = "Ekiti ",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Ado"
                        },
                        new LocalGovernment
                        {
                            Name ="Ekiti East"
                        },
                        new LocalGovernment
                        {
                            Name ="Emure/Ise/Orun"
                        },
                        new LocalGovernment
                        {
                            Name ="Ekiti South West"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikare"
                        },
                        new LocalGovernment
                        {
                            Name ="Irepodun"
                        },
                        new LocalGovernment
                        {
                            Name ="Ijero"
                        },
                        new LocalGovernment
                        {
                            Name ="Ido/Osi"
                        },
                        new LocalGovernment
                        {
                            Name ="Oye"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikole"
                        },
                        new LocalGovernment
                        {
                            Name ="Moba"
                        },
                        new LocalGovernment
                        {
                            Name ="Gbonyin"
                        },
                        new LocalGovernment
                        {
                            Name ="Efon"
                        },
                        new LocalGovernment
                        {
                            Name ="Ise/Orun"
                        },
                        new LocalGovernment
                        {
                            Name ="Ilejemeje"
                        },
                        new LocalGovernment
                        {
                            Name ="Ekiti West"
                        }
                    }
                };
                var enugu = new State
                {
                    Name = "Enugu",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Enugu South"
                        },
                         new LocalGovernment
                        {
                            Name ="Igbo Eze South"
                        },
                          new LocalGovernment
                        {
                            Name ="Enugu North"
                        },
                           new LocalGovernment
                        {
                            Name ="Nkanu"
                        },
                            new LocalGovernment
                        {
                            Name ="Udi Agwu"
                        },
                             new LocalGovernment
                        {
                            Name ="Oji River"
                        },
                              new LocalGovernment
                        {
                            Name ="Ezeagu"
                        },
                               new LocalGovernment
                        {
                            Name ="IgboEze North"
                        },
                                new LocalGovernment
                        {
                            Name ="Isi Uzo"
                        },
                                 new LocalGovernment
                        {
                            Name ="Nsukka"
                        },
                                  new LocalGovernment
                        {
                            Name ="Igbo Ekiti"
                        },
                                   new LocalGovernment
                        {
                            Name ="Uzo Uwani"
                        },
                                    new LocalGovernment
                        {
                            Name ="Enugu Eas"
                        },
                                     new LocalGovernment
                        {
                            Name ="Aninri"
                        },
                                      new LocalGovernment
                        {
                            Name ="Nkanu East"
                        },
                                       new LocalGovernment
                        {
                            Name ="Udenu"
                        }
                    }
                };

                var abuja = new State
                {
                    Name = "Abuja",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Gwagwalada"
                        },
                         new LocalGovernment
                        {
                            Name ="Kuje"
                        },
                          new LocalGovernment
                        {
                            Name ="Abaji"
                        },
                           new LocalGovernment
                        {
                            Name ="Abuja Municipal"
                        },
                            new LocalGovernment
                        {
                            Name ="Bwari"
                        },
                             new LocalGovernment
                        {
                            Name ="Kwali"
                        }
                    }
                };

                var gombe = new State
                {
                    Name = "Gombe",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Akko"
                        },
                        new LocalGovernment
                        {
                            Name ="Balanga"
                        },
                        new LocalGovernment
                        {
                            Name ="Billiri"
                        },
                        new LocalGovernment
                        {
                            Name ="Dukku"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaltungo"
                        },
                        new LocalGovernment
                        {
                            Name ="Kwami"
                        },
                        new LocalGovernment
                        {
                            Name ="Shomgom"
                        },
                        new LocalGovernment
                        {
                            Name ="Funakaye"
                        },
                        new LocalGovernment
                        {
                            Name ="Gombe"
                        },
                        new LocalGovernment
                        {
                            Name ="Nafada/Bajoga"
                        },
                        new LocalGovernment
                        {
                            Name ="Yamaltu/Delta"
                        }
                    }
                };

                var imo = new State
                {
                    Name = "Imo",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Aboh Mbaise"
                        },
                         new LocalGovernment
                        {
                            Name ="Ahiazu Mbaise"
                        },
                          new LocalGovernment
                        {
                            Name ="Ehime Mbano"
                        },
                           new LocalGovernment
                        {
                            Name ="Ezinihitte"
                        },
                        new LocalGovernment
                        {
                            Name ="Ideato North"
                        },
                         new LocalGovernment
                        {
                            Name ="Ideato South"
                        },
                        new LocalGovernment
                        {
                            Name ="Ideato South"
                        },
                        new LocalGovernment
                        {
                            Name ="Ihitte/Uboma"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikeduru"
                        },
                        new LocalGovernment
                        {
                            Name ="Isiala Mbano"
                        },
                          new LocalGovernment
                        {
                            Name ="Isu"
                        },
                          new LocalGovernment
                        {
                            Name ="Mbaitoli"
                        },
                        new LocalGovernment
                        {
                            Name ="Mbaitoli"
                        },
                        new LocalGovernment
                        {
                            Name ="Ngor Okpala"
                        },
                       new LocalGovernment
                        {
                            Name ="Njaba"
                        },
                        new LocalGovernment
                        {
                            Name ="Nwangele"
                        },
                        new LocalGovernment
                        {
                            Name ="Nkwerre"
                        },
                        new LocalGovernment
                        {
                            Name ="Obowo"
                        },
                        new LocalGovernment
                        {
                            Name ="Oguta"
                        },
                        new LocalGovernment
                        {
                            Name ="Ohaji/Egbema"
                        },
                        new LocalGovernment
                        {
                            Name ="Okigwe"
                        },
                      new LocalGovernment
                        {
                            Name ="Orlu"
                        },
                        new LocalGovernment
                        {
                            Name ="Orsu"
                        },
                      new LocalGovernment
                        {
                            Name ="Oru East"
                        },
                        new LocalGovernment
                        {
                            Name ="Oru West"
                        },
                       new LocalGovernment
                        {
                            Name ="Owerri Municipal"
                        },
                        new LocalGovernment
                        {
                            Name ="Owerri North"
                        },
                        new LocalGovernment
                        {
                            Name ="Owerri West"
                        }
                    }
                };

                var jigawa = new State
                {
                    Name = "Jigawa",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Auyo"
                        },
                        new LocalGovernment
                        {
                            Name ="Babura"
                        },
                        new LocalGovernment
                        {
                            Name ="Birni Kudu"
                        },
                        new LocalGovernment
                        {
                            Name ="Biriniwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Buji"
                        },
                        new LocalGovernment
                        {
                            Name ="Dutse"
                        },
                        new LocalGovernment
                        {
                            Name ="Gagarawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Garki"
                        },
                        new LocalGovernment
                        {
                            Name ="Gumel"
                        },
                        new LocalGovernment
                        {
                            Name ="Guri"
                        },
                        new LocalGovernment
                        {
                            Name ="Gwaram"
                        },
                        new LocalGovernment
                        {
                            Name ="Gwiwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Hadejia"
                        },
                        new LocalGovernment
                        {
                            Name ="Jahun"
                        },
                        new LocalGovernment
                        {
                            Name ="Kafin Hausa"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaugama Kazaure"
                        },
                        new LocalGovernment
                        {
                            Name ="Kazaure"
                        },
                        new LocalGovernment
                        {
                            Name ="Kiri Kasamma"
                        },
                        new LocalGovernment
                        {
                            Name ="Maigatari"
                        },
                        new LocalGovernment
                        {
                            Name ="Malam Madori"
                        },
                        new LocalGovernment
                        {
                            Name ="Miga"
                        },
                        new LocalGovernment
                        {
                            Name ="Ringim"
                        },
                        new LocalGovernment
                        {
                            Name ="Roni"
                        },
                        new LocalGovernment
                        {
                            Name ="Sule Tankarkar"
                        },
                        new LocalGovernment
                        {
                            Name ="Taura"
                        },
                        new LocalGovernment
                        {
                            Name ="Yankwashi"
                        }
                    }
                };

                var kaduna = new State
                {
                    Name = "Kaduna",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Birni Gwari"
                        },
                        new LocalGovernment
                        {
                            Name ="Chikun"
                        },
                        new LocalGovernment
                        {
                            Name ="Giwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Igabi"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikara"
                        },
                        new LocalGovernment
                        {
                            Name ="Jaba"
                        },
                        new LocalGovernment
                        {
                            Name ="Jema’a"
                        },
                        new LocalGovernment
                        {
                            Name ="Kachia"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaduna North"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaduna South"
                        },
                        new LocalGovernment
                        {
                            Name ="Kagarko"
                        },new LocalGovernment
                        {
                            Name ="Kajuru"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaura"
                        },
                        new LocalGovernment
                        {
                            Name ="Kauru"
                        },
                        new LocalGovernment
                        {
                            Name ="Kubau"
                        },
                        new LocalGovernment
                        {
                            Name ="Kudan"
                        },
                        new LocalGovernment
                        {
                            Name ="Lere"
                        },
                        new LocalGovernment
                        {
                            Name ="Makarfi"
                        },
                        new LocalGovernment
                        {
                            Name ="Sabon Gari"
                        },
                        new LocalGovernment
                        {
                            Name ="Sanga"
                        },
                        new LocalGovernment
                        {
                            Name ="Soba"
                        },
                        new LocalGovernment
                        {
                            Name ="Zango Kataf"
                        },
                        new LocalGovernment
                        {
                            Name ="Zaria"
                        }
                    }
                };

                var kano = new State
                {
                    Name = "Kano",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Ajingi"
                        },
                        new LocalGovernment
                        {
                            Name ="Albasu"
                        },
                        new LocalGovernment
                        {
                            Name ="Bagwai"
                        },
                        new LocalGovernment
                        {
                            Name ="Bebeji"
                        },
                        new LocalGovernment
                        {
                            Name ="Bichi"
                        },
                        new LocalGovernment
                        {
                            Name ="Bunkure"
                        },
                        new LocalGovernment
                        {
                            Name ="Dala"
                        },
                        new LocalGovernment
                        {
                            Name ="Dambatta"
                        },
                        new LocalGovernment
                        {
                            Name ="Dawakin Kudu"
                        },
                        new LocalGovernment
                        {
                            Name ="Dawakin Tofa"
                        },
                        new LocalGovernment
                        {
                            Name ="Doguwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Fagge"
                        },
                        new LocalGovernment
                        {
                            Name ="Gabasawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Garko"
                        },
                        new LocalGovernment
                        {
                            Name ="Garum"
                        },
                        new LocalGovernment
                        {
                            Name ="Mallam"
                        },
                        new LocalGovernment
                        {
                            Name ="Gaya"
                        },
                        new LocalGovernment
                        {
                            Name ="Gezawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Gwale"
                        },
                        new LocalGovernment
                        {
                            Name ="Gwarzo"
                        },
                        new LocalGovernment
                        {
                            Name ="Kabo"
                        },
                        new LocalGovernment
                        {
                            Name ="Kano Municipal"
                        },
                        new LocalGovernment
                        {
                            Name ="Karaye"
                        },
                        new LocalGovernment
                        {
                            Name ="Kibiya"
                        },
                        new LocalGovernment
                        {
                            Name ="Kiru"
                        },
                        new LocalGovernment
                        {
                            Name ="kumbotso"
                        },
                        new LocalGovernment
                        {
                            Name ="Kunchi"
                        },
                        new LocalGovernment
                        {
                            Name ="Kura"
                        },
                        new LocalGovernment
                        {
                            Name ="Madobi"
                        },
                        new LocalGovernment
                        {
                            Name ="akoda"
                        },
                        new LocalGovernment
                        {
                            Name ="Minjibir"
                        },
                        new LocalGovernment
                        {
                            Name ="Nasarawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Rano"
                        },
                        new LocalGovernment
                        {
                            Name ="Rimin Gado"
                        },
                        new LocalGovernment
                        {
                            Name ="Rogo"
                        },
                        new LocalGovernment
                        {
                            Name ="Shanono"
                        },
                        new LocalGovernment
                        {
                            Name ="Sumaila"
                        },
                        new LocalGovernment
                        {
                            Name ="Takali"
                        },
                        new LocalGovernment
                        {
                            Name ="Tarauni"
                        },
                        new LocalGovernment
                        {
                            Name ="Tofa"
                        },
                        new LocalGovernment
                        {
                            Name ="Tsanyawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Tudun Wada"
                        },
                        new LocalGovernment
                        {
                            Name ="Ungogo"
                        },
                        new LocalGovernment
                        {
                            Name ="Warawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Wudil"
                        }
                    }
                };


                var katsina = new State
                {
                    Name = "Katsina",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Bakori"
                        },
                        new LocalGovernment
                        {
                            Name ="Batagarawa"
                        },
                     new LocalGovernment
                        {
                            Name ="Batsari"
                        },
                      new LocalGovernment
                        {
                            Name ="Baure"
                        },
                       new LocalGovernment
                        {
                            Name ="Bindawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Charanchi"
                        },
                         new LocalGovernment
                        {
                            Name ="Dan Musa"
                        },
                          new LocalGovernment
                        {
                            Name ="Dandume"
                        },
                         new LocalGovernment
                        {
                            Name ="Danja"
                        },
                         new LocalGovernment
                        {
                            Name ="Daura"
                        },
                      new LocalGovernment
                        {
                            Name ="Dutsi"
                        },
                        new LocalGovernment
                        {
                            Name ="Dutsin-Ma"
                        },
                         new LocalGovernment
                        {
                            Name ="Faskari"
                        },
                     new LocalGovernment
                        {
                            Name ="Funtua"
                        },
                       new LocalGovernment
                        {
                            Name ="Ingawa"
                        },
                      new LocalGovernment
                        {
                            Name ="Jibia"
                        },
                     new LocalGovernment
                        {
                            Name ="Kafur"
                        },
                      new LocalGovernment
                        {
                            Name ="Kaita"
                        },
                       new LocalGovernment
                        {
                            Name ="Kankara"
                        },
                     new LocalGovernment
                        {
                            Name ="Kankia"
                        },
                      new LocalGovernment
                        {
                            Name ="Katsina"
                        },
                     new LocalGovernment
                        {
                            Name ="Kurfi"
                        },
                      new LocalGovernment
                        {
                            Name ="Kusada"
                        },
                      new LocalGovernment
                        {
                            Name ="Mai'Adua"
                        },
                        new LocalGovernment
                        {
                            Name ="Malumfashi"
                        },
                     new LocalGovernment
                        {
                            Name ="Mani"
                        },
                      new LocalGovernment
                        {
                            Name ="Mashi"
                        },
                     new LocalGovernment
                        {
                            Name ="Matazu"
                        },
                     new LocalGovernment
                        {
                            Name ="Musawa"
                        },
                    new LocalGovernment
                        {
                            Name ="Rimi"
                        },
                     new LocalGovernment
                        {
                            Name ="Sabuwa"
                        },
                    new LocalGovernment
                        {
                            Name ="Safana"
                        },
                      new LocalGovernment
                        {
                            Name ="Sandamu"
                        },
                       new LocalGovernment
                        {
                            Name ="Zango"
                        }
                    }
                };

                var kebbi = new State
                {
                    Name = "Kebbi",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Aleiro"
                        },
                         new LocalGovernment
                        {
                            Name ="Arewa Dandi"
                        },
                         new LocalGovernment
                        {
                            Name ="Argungu"
                        },
                         new LocalGovernment
                        {
                            Name ="Augie"
                        },
                        new LocalGovernment
                        {
                            Name ="Bagudo"
                        },
                        new LocalGovernment
                        {
                            Name ="Birnin Kebbi"
                        },
                         new LocalGovernment
                        {
                            Name ="Bunza"
                        },
                       new LocalGovernment
                        {
                            Name ="Dandi"
                        },
                        new LocalGovernment
                        {
                            Name ="Fakai"
                        },
                         new LocalGovernment
                        {
                            Name ="Gwandu"
                        },
                        new LocalGovernment
                        {
                            Name ="Jega"
                        },
                        new LocalGovernment
                        {
                            Name ="Kalgo"
                        },
                        new LocalGovernment
                        {
                            Name ="Koko/Besse"
                        },
                        new LocalGovernment
                        {
                            Name ="Maiyama"
                        },
                       new LocalGovernment
                        {
                            Name ="Ngaski"
                        },
                      new LocalGovernment
                        {
                            Name ="Sakaba"
                        },
                        new LocalGovernment
                        {
                            Name ="Shanga"
                        },
                        new LocalGovernment
                        {
                            Name ="Suru"
                        },
                        new LocalGovernment
                        {
                            Name ="Wasagu/Danko"
                        },
                        new LocalGovernment
                        {
                            Name ="Yauri"
                        },
                        new LocalGovernment
                        {
                            Name ="Zuru"
                        }
                    }
                };



                var kogi = new State
                {
                    Name = "Kogi",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Adavi"
                        },
                        new LocalGovernment
                        {
                            Name ="Ajaokuta"
                        },
                        new LocalGovernment
                        {
                            Name ="Ankpa"
                        },
                        new LocalGovernment
                        {
                            Name ="Bassa"
                        },
                        new LocalGovernment
                        {
                            Name ="Dekina"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibaji"
                        },
                        new LocalGovernment
                        {
                            Name ="Idah"
                        },
                        new LocalGovernment
                        {
                            Name ="Igalamela Odolu"
                        },
                        new LocalGovernment
                        {
                            Name ="Ijumu"
                        },
                        new LocalGovernment
                        {
                            Name ="Kabba/Bunu"
                        },
                        new LocalGovernment
                        {
                            Name ="Kogi"
                        },
                        new LocalGovernment
                        {
                            Name ="Lokoja"
                        },
                        new LocalGovernment
                        {
                            Name ="Mopa Muro"
                        },
                        new LocalGovernment
                        {
                            Name ="Ofu"
                        },
                        new LocalGovernment
                        {
                            Name ="Ogori/Mangongo"
                        },
                        new LocalGovernment
                        {
                            Name ="Okehi"
                        },
                        new LocalGovernment
                        {
                            Name ="Okene"
                        },
                        new LocalGovernment
                        {
                            Name ="Olamabolo"
                        },
                        new LocalGovernment
                        {
                            Name ="Omala"
                        },
                        new LocalGovernment
                        {
                            Name ="Yagba_East"
                        },
                        new LocalGovernment
                        {
                            Name ="Yagba_West"
                        }
                    }
                };

                var kwara = new State
                {
                    Name = "",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Asa"
                        },
                        new LocalGovernment
                        {
                            Name ="Baruten"
                        },
                        new LocalGovernment
                        {
                            Name ="Ekiti"
                        },
                        new LocalGovernment
                        {
                            Name ="Ifelodun"
                        },
                        new LocalGovernment
                        {
                            Name ="Ilorin East"
                        },
                        new LocalGovernment
                        {
                            Name ="Ilorin West"
                        },
                        new LocalGovernment
                        {
                            Name ="Ilorin West"
                        },
                        new LocalGovernment
                        {
                            Name ="Isin"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaiama"
                        },
                        new LocalGovernment
                        {
                            Name ="Moro"
                        },
                        new LocalGovernment
                        {
                            Name ="Offa"
                        },
                        new LocalGovernment
                        {
                            Name ="Oke Ero"
                        },
                        new LocalGovernment
                        {
                            Name ="Oyun"
                        },
                        new LocalGovernment
                        {
                            Name ="Pategi"
                        }
                    }
                };

                var lagos = new State
                {
                    Name = "Lagos",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Agege"
                        },
                         new LocalGovernment
                        {
                            Name ="Ajeromi Ifelodun"
                        },
                          new LocalGovernment
                        {
                            Name ="Alimosho"
                        },
                     new LocalGovernment
                        {
                            Name ="Amuwo Odofin"
                        },
                        new LocalGovernment
                        {
                            Name ="Apapa"
                        },
                     new LocalGovernment
                        {
                            Name ="Badagry"
                        },
                      new LocalGovernment
                        {
                            Name ="Epe"
                        },
                      new LocalGovernment
                        {
                            Name ="Eti Osa"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibeju/Lekki"
                        },
                         new LocalGovernment
                        {
                            Name ="Ifako Ijaye"
                        },
                          new LocalGovernment
                        {
                            Name ="Ikeja"
                        },
                         new LocalGovernment
                        {
                            Name ="Ikorodu"
                        },
                        new LocalGovernment
                        {
                            Name ="Kosofe"
                        },
                      new LocalGovernment
                        {
                            Name ="Lagos Island"
                        },
                      new LocalGovernment
                        {
                            Name ="Lagos Mainland"
                        },
                        new LocalGovernment
                        {
                            Name ="Mushin"
                        },
                         new LocalGovernment
                        {
                            Name ="Ojo"
                        },
                       new LocalGovernment
                        {
                            Name ="Oshodi Isolo"
                        },
                       new LocalGovernment
                        {
                            Name ="Shomolu"
                        },
                         new LocalGovernment
                        {
                            Name ="Surulere"
                        }
                    }
                };

                var nasarawa = new State
                {
                    Name = "Nasarawa",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Akwanga"
                        },
                        new LocalGovernment
                        {
                            Name ="Awe"
                        },
                        new LocalGovernment
                        {
                            Name ="Doma"
                        },
                        new LocalGovernment
                        {
                            Name ="Karu"
                        },
                        new LocalGovernment
                        {
                            Name ="Keana"
                        },
                        new LocalGovernment
                        {
                            Name ="Keffi"
                        },
                        new LocalGovernment
                        {
                            Name ="Kokona"
                        },
                        new LocalGovernment
                        {
                            Name ="Lafia"
                        },
                        new LocalGovernment
                        {
                            Name ="Nasarawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Nasarawa Eggon"
                        },
                        new LocalGovernment
                        {
                            Name ="Obi"
                        },
                        new LocalGovernment
                        {
                            Name ="Toto"
                        },
                        new LocalGovernment
                        {
                            Name ="Wamba"
                        }
                    }
                };

                var niger = new State
                {
                    Name = "Niger",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Agaie"
                        },
                         new LocalGovernment
                        {
                            Name ="Agwara"
                        },
                      new LocalGovernment
                        {
                            Name ="Bida"
                        },
                       new LocalGovernment
                        {
                            Name ="Borgu"
                        },
                         new LocalGovernment
                        {
                            Name ="Bosso"
                        },
                           new LocalGovernment
                        {
                            Name ="Chanchaga"
                        },
                       new LocalGovernment
                        {
                            Name ="Edati"
                        },
                       new LocalGovernment
                        {
                            Name ="Gbako"
                        },
                      new LocalGovernment
                        {
                            Name ="Gurara"
                        },
                      new LocalGovernment
                        {
                            Name ="Katcha"
                        },
                      new LocalGovernment
                        {
                            Name ="Kontagora"
                        },
                     new LocalGovernment
                        {
                            Name ="Lapai"
                        },
                   new LocalGovernment
                        {
                            Name ="Lavun"
                        },
                      new LocalGovernment
                        {
                            Name ="Magama"
                        },
                    new LocalGovernment
                        {
                            Name ="Mariga"
                        },
                   new LocalGovernment
                        {
                            Name ="Mashegu"
                        },
                     new LocalGovernment
                        {
                            Name ="Mokwa"
                        },
                    new LocalGovernment
                        {
                            Name ="Muya"
                        },
                       new LocalGovernment
                        {
                            Name ="Pailoro"
                        },
                   new LocalGovernment
                        {
                            Name ="Rafi"
                        },
                     new LocalGovernment
                        {
                            Name ="Rijau"
                        },
                     new LocalGovernment
                        {
                            Name ="Shiroro"
                        },
                    new LocalGovernment
                        {
                            Name ="Suleja"
                        },
                    new LocalGovernment
                        {
                            Name ="Tafa"
                        },
                       new LocalGovernment
                        {
                            Name ="Wushishi"
                        }
                    }
                };

                var ondo = new State
                {
                    Name = "",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Akoko North East"
                        },
                        new LocalGovernment
                        {
                            Name ="Akoko North West"
                        },
                        new LocalGovernment
                        {
                            Name ="Akoko South Akure East"
                        },
                        new LocalGovernment
                        {
                            Name ="Akoko South West"
                        },
                        new LocalGovernment
                        {
                            Name ="Akure North"
                        },
                        new LocalGovernment
                        {
                            Name ="Akure South"
                        },
                        new LocalGovernment
                        {
                            Name ="Ese Odo"
                        },
                        new LocalGovernment
                        {
                            Name ="Idanre"
                        },
                        new LocalGovernment
                        {
                            Name ="Ifedore"
                        },
                        new LocalGovernment
                        {
                            Name ="Ilaje"
                        },
                        new LocalGovernment
                        {
                            Name ="Ile Oluji"
                        },
                        new LocalGovernment
                        {
                            Name ="Okeigbo"
                        },
                        new LocalGovernment
                        {
                            Name ="Irele"
                        },
                        new LocalGovernment
                        {
                            Name ="Odigbo"
                        },
                        new LocalGovernment
                        {
                            Name ="Okitipupa"
                        },
                        new LocalGovernment
                        {
                            Name ="Ondo East"
                        },
                        new LocalGovernment
                        {
                            Name ="Ondo West"
                        },
                        new LocalGovernment
                        {
                            Name ="Ose"
                        },
                        new LocalGovernment
                        {
                            Name ="Owo"
                        }
                    }
                };

                var osun = new State
                {
                    Name = "Osun",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Aiyedade"
                        },
                        new LocalGovernment
                        {
                            Name ="Aiyedire"
                        },
                        new LocalGovernment
                        {
                            Name ="Atakumosa East"
                        },
                        new LocalGovernment
                        {
                            Name ="Atakumosa West"
                        },
                        new LocalGovernment
                        {
                            Name ="Boluwaduro"
                        },
                        new LocalGovernment
                        {
                            Name ="Boripe"
                        },
                        new LocalGovernment
                        {
                            Name ="Ede North"
                        },
                        new LocalGovernment
                        {
                            Name ="Ede South"
                        },
                        new LocalGovernment
                        {
                            Name ="Egbedore"
                        },
                        new LocalGovernment
                        {
                            Name ="Ejigbo"
                        },
                        new LocalGovernment
                        {
                            Name ="Ife Central"
                        },
                        new LocalGovernment
                        {
                            Name ="Ife East"
                        },
                        new LocalGovernment
                        {
                            Name ="Ife North"
                        },
                        new LocalGovernment
                        {
                            Name ="Ife South"
                        },
                        new LocalGovernment
                        {
                            Name ="Ifedayo"
                        },
                        new LocalGovernment
                        {
                            Name ="Ifelodun"
                        },
                        new LocalGovernment
                        {
                            Name ="Ila"
                        },
                        new LocalGovernment
                        {
                            Name ="Ilesha East"
                        },
                        new LocalGovernment
                        {
                            Name ="Ilesha West"
                        },
                        new LocalGovernment
                        {
                            Name ="Irepodun"
                        },
                        new LocalGovernment
                        {
                            Name ="Irewole"
                        },
                        new LocalGovernment
                        {
                            Name ="Isokan"
                        },
                        new LocalGovernment
                        {
                            Name ="Iwo"
                        },
                        new LocalGovernment
                        {
                            Name ="Obokun"
                        },
                        new LocalGovernment
                        {
                            Name ="Odo Otin"
                        },
                        new LocalGovernment
                        {
                            Name ="Ola Oluwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Olorunda"
                        },
                        new LocalGovernment
                        {
                            Name ="Oriade"
                        },
                        new LocalGovernment
                        {
                            Name ="Orolu"
                        },
                        new LocalGovernment
                        {
                            Name ="Osogbo"
                        }
                    }
                };

                var oyo = new State
                {
                    Name = "Oyo",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Afijio"
                        },
                        new LocalGovernment
                        {
                            Name ="Akinyele"
                        },
                        new LocalGovernment
                        {
                            Name ="Atiba"
                        },
                        new LocalGovernment
                        {
                            Name ="Atigbo"
                        },
                        new LocalGovernment
                        {
                            Name ="Egbeda"
                        },
                        new LocalGovernment
                        {
                            Name ="IbadanCentral"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibadan North"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibadan North West"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibadan South East"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibadan South West"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibarapa Central"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibarapa East"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibarapa North"
                        },
                        new LocalGovernment
                        {
                            Name ="Ido"
                        },
                        new LocalGovernment
                        {
                            Name ="Irepo"
                        },
                        new LocalGovernment
                        {
                            Name ="Iseyin"
                        },
                        new LocalGovernment
                        {
                            Name ="Itesiwaju"
                        },
                        new LocalGovernment
                        {
                            Name ="Iwajowa"
                        },
                        new LocalGovernment
                        {
                            Name ="Kajola"
                        },
                        new LocalGovernment
                        {
                            Name ="Lagelu Ogbomosho North"
                        },
                        new LocalGovernment
                        {
                            Name ="Ogbmosho South"
                        },
                        new LocalGovernment
                        {
                            Name ="Ogo Oluwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Olorunsogo"
                        },
                        new LocalGovernment
                        {
                            Name ="Oluyole"
                        },
                        new LocalGovernment
                        {
                            Name ="Ona-Ara"
                        },
                        new LocalGovernment
                        {
                            Name ="Orelope"
                        },
                        new LocalGovernment
                        {
                            Name ="Ori Ire"
                        },
                        new LocalGovernment
                        {
                            Name ="Oyo East"
                        },
                        new LocalGovernment
                        {
                            Name ="Oyo West"
                        },
                        new LocalGovernment
                        {
                            Name ="Saki East"
                        },
                        new LocalGovernment
                        {
                            Name ="Saki West"
                        },
                        new LocalGovernment
                        {
                            Name ="Surulere"
                        }
                    }
                };

                var plateau = new State
                {
                    Name = "Plateau ",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Barikin Ladi"
                        },
                        new LocalGovernment
                        {
                            Name ="Bassa"
                        },
                        new LocalGovernment
                        {
                            Name ="Bokkos"
                        },
                        new LocalGovernment
                        {
                            Name ="Jos East"
                        },
                        new LocalGovernment
                        {
                            Name ="Jos North"
                        },
                        new LocalGovernment
                        {
                            Name ="Jos South"
                        },
                        new LocalGovernment
                        {
                            Name ="Kanam"
                        },
                        new LocalGovernment
                        {
                            Name ="Kanke"
                        },
                        new LocalGovernment
                        {
                            Name ="Langtang North"
                        },
                        new LocalGovernment
                        {
                            Name ="Langtang South"
                        },
                        new LocalGovernment
                        {
                            Name ="Mangu"
                        },
                        new LocalGovernment
                        {
                            Name ="Mikang"
                        },
                        new LocalGovernment
                        {
                            Name ="Pankshin"
                        },
                        new LocalGovernment
                        {
                            Name ="Qua’an Pan"
                        },
                        new LocalGovernment
                        {
                            Name ="Riyom"
                        },
                        new LocalGovernment
                        {
                            Name ="Shendam"
                        },
                        new LocalGovernment
                        {
                            Name ="Wase"
                        }
                    }
                };

                var rivers = new State
                {
                    Name = "Rivers",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Abua/Odual"
                        },
                        new LocalGovernment
                        {
                            Name ="Ahoada East"
                        },
                        new LocalGovernment
                        {
                            Name ="Ahoada West"
                        },
                        new LocalGovernment
                        {
                            Name ="Akuku Toru"
                        },
                        new LocalGovernment
                        {
                            Name ="Andoni"
                        },
                        new LocalGovernment
                        {
                            Name ="Asari Toru"
                        },
                        new LocalGovernment
                        {
                            Name ="Bonny"
                        },
                        new LocalGovernment
                        {
                            Name ="Degema"
                        },
                        new LocalGovernment
                        {
                            Name ="Emohua"
                        },
                        new LocalGovernment
                        {
                            Name ="Eleme"
                        },
                        new LocalGovernment
                        {
                            Name ="Etche"
                        },
                        new LocalGovernment
                        {
                            Name ="Gokana"
                        },
                        new LocalGovernment
                        {
                            Name ="Ikwerre"
                        },
                        new LocalGovernment
                        {
                            Name ="Khana"
                        },
                        new LocalGovernment
                        {
                            Name ="Obia/Akpor"
                        },
                        new LocalGovernment
                        {
                            Name ="Ogba/Egbema/Ndoni"
                        },
                        new LocalGovernment
                        {
                            Name ="Ogu/Bolo"
                        },
                        new LocalGovernment
                        {
                            Name ="Okrika"
                        },
                        new LocalGovernment
                        {
                            Name ="Omumma"
                        },
                        new LocalGovernment
                        {
                            Name ="Opobo/Nkoro"
                        },
                        new LocalGovernment
                        {
                            Name ="Oyigbo"
                        },
                        new LocalGovernment
                        {
                            Name ="Port Harcourt"
                        },
                        new LocalGovernment
                        {
                            Name ="Tai"
                        }
                    }
                };

                var sokoto = new State
                {
                    Name = "Sokoto",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Binji"
                        },
                        new LocalGovernment
                        {
                            Name ="Bodinga"
                        },
                        new LocalGovernment
                        {
                            Name ="Dange Shnsi"
                        },
                        new LocalGovernment
                        {
                            Name ="Gada"
                        },
                        new LocalGovernment
                        {
                            Name ="Goronyo"
                        },
                        new LocalGovernment
                        {
                            Name ="Gudu"
                        },
                        new LocalGovernment
                        {
                            Name ="Gawabawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Illela"
                        },
                        new LocalGovernment
                        {
                            Name ="Isa"
                        },
                        new LocalGovernment
                        {
                            Name ="Kware"
                        },
                        new LocalGovernment
                        {
                            Name ="kebbe"
                        },
                        new LocalGovernment
                        {
                            Name ="Rabah"
                        },
                        new LocalGovernment
                        {
                            Name ="Sabon birni"
                        },
                        new LocalGovernment
                        {
                            Name ="Shagari"
                        },
                        new LocalGovernment
                        {
                            Name ="Silame"
                        },
                        new LocalGovernment
                        {
                            Name ="Sokoto North"
                        },
                        new LocalGovernment
                        {
                            Name ="Sokoto South"
                        },
                        new LocalGovernment
                        {
                            Name ="Tambuwal"
                        },
                        new LocalGovernment
                        {
                            Name ="Tqngaza"
                        },
                        new LocalGovernment
                        {
                            Name ="Tureta"
                        },
                        new LocalGovernment
                        {
                            Name ="Wamako"
                        },
                        new LocalGovernment
                        {
                            Name ="Wurno"
                        },
                        new LocalGovernment
                        {
                            Name ="Yabo"
                        }
                    }
                };

                var taraba = new State
                {
                    Name = "Taraba",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Ardo kola"
                        },
                        new LocalGovernment
                        {
                            Name ="Bali"
                        },
                        new LocalGovernment
                        {
                            Name ="Donga"
                        },
                        new LocalGovernment
                        {
                            Name ="Gashaka"
                        },
                        new LocalGovernment
                        {
                            Name ="Cassol"
                        },
                        new LocalGovernment
                        {
                            Name ="Ibi"
                        },
                        new LocalGovernment
                        {
                            Name ="Jalingo"
                        },
                        new LocalGovernment
                        {
                            Name ="Karin Lamido"
                        },
                        new LocalGovernment
                        {
                            Name ="Kurmi"
                        },
                        new LocalGovernment
                        {
                            Name ="Lau"
                        },
                        new LocalGovernment
                        {
                            Name ="Sardauna"
                        },
                        new LocalGovernment
                        {
                            Name ="Takum"
                        },
                        new LocalGovernment
                        {
                            Name ="Ussa"
                        },
                        new LocalGovernment
                        {
                            Name ="Wukari"
                        },
                        new LocalGovernment
                        {
                            Name ="Yorro"
                        },
                        new LocalGovernment
                        {
                            Name ="Zing"
                        }
                    }
                };

                var yobe = new State
                {
                    Name = "Yobe",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Bade"
                        },
                        new LocalGovernment
                        {
                            Name ="Bursari"
                        },
                        new LocalGovernment
                        {
                            Name ="Damaturu"
                        },
                        new LocalGovernment
                        {
                            Name ="Fika"
                        },
                        new LocalGovernment
                        {
                            Name ="Fune"
                        },
                        new LocalGovernment
                        {
                            Name ="Geidam"
                        },
                        new LocalGovernment
                        {
                            Name ="Gujba"
                        },
                        new LocalGovernment
                        {
                            Name ="Gulani"
                        },
                        new LocalGovernment
                        {
                            Name ="Jakusko"
                        },
                        new LocalGovernment
                        {
                            Name ="Karasuwa"
                        },
                        new LocalGovernment
                        {
                            Name ="Karawa"
                        },
                        new LocalGovernment
                        {
                            Name ="Machina"
                        },
                        new LocalGovernment
                        {
                            Name ="Nangere"
                        },
                        new LocalGovernment
                        {
                            Name ="Nguru Potiskum"
                        },
                        new LocalGovernment
                        {
                            Name ="Tarmua"
                        },
                        new LocalGovernment
                        {
                            Name ="Yunusari"
                        },
                        new LocalGovernment
                        {
                            Name ="Yusufari"
                        }
                    }
                };

                var zamfara = new State
                {
                    Name = "Zamfara",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment
                        {
                            Name ="Anka"
                        },
                        new LocalGovernment
                        {
                            Name ="Bakura"
                        },
                        new LocalGovernment
                        {
                            Name ="Birnin Magaji"
                        },
                        new LocalGovernment
                        {
                            Name ="Bukkuyum"
                        },
                        new LocalGovernment
                        {
                            Name ="Bungudu"
                        },
                        new LocalGovernment
                        {
                            Name ="Gummi"
                        },
                        new LocalGovernment
                        {
                            Name ="Gusau"
                        },
                        new LocalGovernment
                        {
                            Name ="Kaura"
                        },
                        new LocalGovernment
                        {
                            Name ="Namoda"
                        },
                        new LocalGovernment
                        {
                            Name ="Maradun"
                        },
                        new LocalGovernment
                        {
                            Name ="Maru"
                        },
                        new LocalGovernment
                        {
                            Name ="Shinkafi"
                        },
                        new LocalGovernment
                        {
                            Name ="Talata Mafara"
                        },
                        new LocalGovernment
                        {
                            Name ="Tsafe"
                        },
                        new LocalGovernment
                        {
                            Name ="Zurmi"
                        }
                    }
                };

                var ogun = new State
                {
                    Name = "Ogun",
                    LocalGovt = new List<LocalGovernment>
                    {
                        new LocalGovernment {
                            Name = "Ifo"
                        },
                        new LocalGovernment {
                            Name = "Ado-Odo/Ota"
                        },
                        new LocalGovernment {
                            Name = "Ijebu North"
                        },
                        new LocalGovernment {
                            Name = "Shagamu"
                        },
                        new LocalGovernment {
                            Name = "Abeokuta South"
                        },
                        new LocalGovernment {
                            Name = "Obafemi-Owode"
                        },
                        new LocalGovernment {
                            Name = "Abeokuta North"
                        },
                        new LocalGovernment {
                            Name = "Egbado North"
                        },
                        new LocalGovernment {
                            Name = "Egbado South"
                        },
                        new LocalGovernment {
                            Name = "Ijebu Ode"
                        },
                        new LocalGovernment {
                            Name = "Ipokia"
                        },
                        new LocalGovernment {
                            Name = "Odogbolu"
                        },
                        new LocalGovernment {
                            Name = "Ikenne"
                        },
                        new LocalGovernment {
                            Name = "Odeda"
                        },
                        new LocalGovernment {
                            Name = "Ijebu East"
                        },
                        new LocalGovernment {
                            Name = "Imeko Afon"
                        },
                        new LocalGovernment {
                            Name = "Ogun Waterside"
                        },
                        new LocalGovernment {
                            Name = "Ijebu North East"
                        },
                        new LocalGovernment {
                            Name = "Remo North"
                        },
                        new LocalGovernment {
                            Name = "Ewekoro"
                        }
                    }
                };

                ctx.States.AddOrUpdate(abiaState);
                ctx.States.AddOrUpdate(adamawa);
                ctx.States.AddOrUpdate(akwaIbom);
                ctx.States.AddOrUpdate(anambra);
                ctx.States.AddOrUpdate(bauchi);
                ctx.States.AddOrUpdate(bayelsa);
                ctx.States.AddOrUpdate(benue);
                ctx.States.AddOrUpdate(borno);
                ctx.States.AddOrUpdate(crossRiver);
                ctx.States.AddOrUpdate(delta);
                ctx.States.AddOrUpdate(ebonyi);
                ctx.States.AddOrUpdate(edo);
                ctx.States.AddOrUpdate(ekiti);
                ctx.States.AddOrUpdate(enugu);
                ctx.States.AddOrUpdate(gombe);
                ctx.States.AddOrUpdate(imo);
                ctx.States.AddOrUpdate(jigawa);
                ctx.States.AddOrUpdate(kaduna);
                ctx.States.AddOrUpdate(kano);
                ctx.States.AddOrUpdate(katsina);
                ctx.States.AddOrUpdate(kebbi);
                ctx.States.AddOrUpdate(kogi);
                ctx.States.AddOrUpdate(kwara);
                ctx.States.AddOrUpdate(lagos);
                ctx.States.AddOrUpdate(nasarawa);
                ctx.States.AddOrUpdate(niger);
                ctx.States.AddOrUpdate(osun);
                ctx.States.AddOrUpdate(oyo);
                ctx.States.AddOrUpdate(plateau);
                ctx.States.AddOrUpdate(rivers);
                ctx.States.AddOrUpdate(sokoto);
                ctx.States.AddOrUpdate(taraba);
                ctx.States.AddOrUpdate(yobe);
                ctx.States.AddOrUpdate(abuja);
                ctx.States.AddOrUpdate(zamfara);
                ctx.States.AddOrUpdate(ogun);


                ctx.SaveChanges();
            }

        }
    }
}
