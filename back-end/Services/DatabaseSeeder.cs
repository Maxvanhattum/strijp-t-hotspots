using Models;
using Repositories.Contracts;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IHotspotRepository hotspotRepository;

        public DatabaseSeeder(IHotspotRepository hotspotRepository)
        {
            this.hotspotRepository = hotspotRepository;
        }

        public void SeedHotspots()
        {
            if (hotspotRepository.GetById(1) == null)
            {
                Hotspot hotspotTQ1 = new Hotspot("Hotspot TQ1", "TQ is verreweg het grootste gebouw van Strijp-T, welkom bij ingang 1.",
                DateTime.Now,
                new GeoCoordinates("5.4522929", "51.4509177"),
                new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/ggtN8t9j1UQ", "Strijp Talk - Wim Troost", "Grondlegger van ASML die vanuit gebouw TQ ervoor heeft gezorgd dat vanaf 1 april 1984 de eerste huisvesting van ASML in een houten keet in de binnentuin tussen gebouw TQ 1 en TQ 2 plaats vond.", "Strijp-T"),
                new AR360("path"));

                List<Business> businessesTQ1 = new List<Business>() {
                new Business("Flowid B.V", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "157-C"), "https://www.flowid.nl/"),
                new Business("HVR Engineering", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "157-A"), "https://www.hvrengineering.com/"),
                new Business("Paul Raats 'Creative Views'", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "157-B"), "https://www.paulraats.com/home")
                };

                hotspotTQ1.Businesses = businessesTQ1;
                hotspotRepository.Add(hotspotTQ1);

                Hotspot hotspotTQ3 = new Hotspot("Hotspot TQ3", "TQ is verreweg het grootste gebouw van Strijp-T, welkom bij ingang 3.",
                DateTime.Now,
                new GeoCoordinates("5.4536007", "51.4503887"),
                new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/CXLPfvuXYlY",
                "Strijp Talk 4- Fred Bok", "Op Strijp-T is de basis gelegd voor zijn internationale carrière binnen Philips. " +
                "Tevens is hier vanuit gebouw TQ de basis gelegd voor het huidige hoogwaardige High Tech niveau dat de regio Brainport Eindhoven nog steeds kenmerkt.", "Strijp-T"),
                new AR360("path"));

                List<Business> businessesTQ3 = new List<Business>() {
                new Business("Antea group", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153"), "https://anteagroup.nl/"),
                new Business("Avular B.V.", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-G"), "https://avular.com/"),
                new Business("Eindhoven Gym B.V", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-A"), "https://eindhovengym.nl/"),
                new Business("Elstar Dynamics", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-V"), "https://elstar-dynamics.com/"),
                new Business("Interstep", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153"), "https://www.interstep.nl/")
                };

                hotspotTQ3.Businesses = businessesTQ3;
                hotspotRepository.Add(hotspotTQ3);

                // VIDEO & BEDRIJVEN TQ4
                Hotspot hotspotTQ4 = new Hotspot("Hotspot TQ4", "TQ is verreweg het grootste gebouw van Strijp-T, welkom bij ingang 4.",
                DateTime.Now,
                new GeoCoordinates("5.4538037", "51.4505662"),
                new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/CXLPfvuXYlY",
                "Strijp Talk 4- Fred Bok", "Op Strijp-T is de basis gelegd voor zijn internationale carrière binnen Philips. " +
                "Tevens is hier vanuit gebouw TQ de basis gelegd voor het huidige hoogwaardige High Tech niveau dat de regio Brainport Eindhoven nog steeds kenmerkt.", "Strijp-T"),
                new AR360("path"));

                List<Business> businessesTQ4 = new List<Business>() {
                new Business("24U in bedrijf (de Zaak)", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-B"), "https://24uurinbedrijf.nl/"),
                new Business("AAS International", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-C"), "WEBSITE: https://aasinternational.nl/"),
                new Business("B-Invented B.V", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-M"), "https://b-invented.com/"),
                new Business("Deity B.V", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-F"), "https://deity.io/"),
                new Business("Ennatuurlijk B.V.", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-X"), "https://ennatuurlijk.nl/"),
                new Business("Interlingo", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-B"), "https://www.interlingo.nl/"),
                new Business("Kramer Reclame", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153"), "WEBSITE: http://kramerreclame.nl/"),
                new Business("LEBA Benelux", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-R"), "http://www.lebabenelux.nl/"),
                new Business("Sahara Europe", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-R"), "https://www.saharabenelux.nl/"),
                new Business("Signet IT-Ernity Holding B.V.", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-W"), "https://www.signet.nl/"),
                new Business("Studio op TQ", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-R"), "https://www.idstrijp.nl/studio-op-tq/"),
                new Business("Sturrm", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153"), "https://sturrm.nl/"),
                new Business("Vascobelo", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-D"), "https://vascobelo.com/"),
                new Business("Volantis B.V", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "153-E"), "https://www.volantis.nl/")
                };

                hotspotTQ4.Businesses = businessesTQ4;
                hotspotRepository.Add(hotspotTQ4);

                //Video's en bedrijven TQ5 

                Hotspot hotspotTQ5 = new Hotspot("Hotspot TQ5", "TQ is verreweg het grootste gebouw van Strijp-T, welkom bij ingang 5.",
                DateTime.Now,
                new GeoCoordinates("5.4539718", "51.4514141"),
                new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/-oDaqgMHSG8",
                "Strijp Talk 7 – Chris van den Biggelaar", "Was werkzaam in gebouw TQ bij Philips in het magazijn als inpakker in de jaren 60-70.", "Strijp-T"),
                new AR360("path"));

                List<Business> businessesTQ5 = new List<Business>() {
                new Business("ABB", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "151-A"), "https://new.abb.com/benelux/over-ons"),
                new Business("AFA Dispensing Technologies", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "151-B"), "https://www.afadispensing.com/"),
                new Business("AirLiquide", new Address("Eindhoven", "5651GW", "Achtsteweg Zuid", "151-B"),"https://industrie.airliquide-benelux.com/belgie-nederland")
                };

                hotspotTQ5.Businesses = businessesTQ5;
                hotspotRepository.Add(hotspotTQ5);

                Hotspot hotspotTAB = new Hotspot("Hotspot TAB", "Industrieel erfgoed aan de rand van het stadscentrum, gelegen in het groen.",
                   DateTime.Now,
                   new GeoCoordinates("5.4515901", "51.4525743"),
                   new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/3kds0oufkHI",
                   "Strijp Talk 5", "Heeft in gebouw TAB begin jaren 90 met veel plezier richting en inhoud gegeven aan de eerste prototype werkplaats, als zelfstandige unit binnen de machinefabriek van Philips.", "Strijp-T"),
                   new AR360("path"));

                List<Business> businessesTAB = new List<Business>() {
                new Business("Daphna Laurens V.O.F.", new Address("Eindhoven", "5651GW ", "Achtsteweg Zuid", "161D"), "https://www.daphnalaurens.nl/"),
                new Business("de Materiaalfabriek (Labii Holding)", new Address("Eindhoven", "5651GW ", "Achtsteweg Zuid", "161G"), "http://www.laboravision.nl/"),
                new Business("Mikomax Nederland B.V", new Address("Eindhoven", "5651GW ", "Achtsteweg Zuid", "161F"), "https://www.mikomax.nl/"),
                };

                hotspotTAB.Businesses = businessesTAB;
                hotspotRepository.Add(hotspotTAB);

                Hotspot hotspotTAE = new Hotspot("Hotspot TAE", "Gelegen achter TAB",
                   DateTime.Now,
                   new GeoCoordinates("5.4513241", "51.4530920"),
                   new MovieInterviewDetails(),
                   new AR360("path"));

                List<Business> businessesTAE = new List<Business>() {
                new Business("TWOFIFTYK", new Address("Eindhoven", "5651CA ", "Achtsteweg Zuid", "171"), "http://www.250k.nl/projects/")
                };

                hotspotTAE.Businesses = businessesTAE;
                hotspotRepository.Add(hotspotTAE);

                Hotspot hotspotTAQ = new Hotspot("Hotspot TAQ", "Het voormalig Pomphuis",
                   DateTime.Now,
                   new GeoCoordinates("5.4476856", "51.4540303"),
                   new MovieInterviewDetails(),
                   new AR360("path"));

                List<Business> businessesTAQ = new List<Business>() {
                new Business("Settels Savenije Van Amelsvoort B.V.", new Address("Eindhoven", "5651GW ", "Achtsteweg Zuid", "211"), "https://www.sttls.nl/")
                };

                hotspotTAQ.Businesses = businessesTAQ;
                hotspotRepository.Add(hotspotTAQ);

                Hotspot hotspotTAT = new Hotspot("Hotspot TAT", "Gelegen aan spoorzijde",
                   DateTime.Now,
                   new GeoCoordinates("5.4512609", "51.4535216"),
                   new MovieInterviewDetails(),
                   new AR360("path"));

                List<Business> businessesTAT = new List<Business>() {
                new Business("Bronk Industrial B.V.", new Address("Eindhoven", "5651CA ", "Achtsteweg Zuid", "181"), "-")
                };

                hotspotTAT.Businesses = businessesTAT;
                hotspotRepository.Add(hotspotTAT);

                Hotspot hotspotTT = new Hotspot("Hotspot TT", "Gelegen tussen TZ en TR",
                   DateTime.Now,
                   new GeoCoordinates("5.4499735", "51.4509789"),
                   new MovieInterviewDetails(),
                   new AR360("path"));

                List<Business> businessesTT = new List<Business>() {
                new Business("B-Too", new Address("Eindhoven", "5651CA ", "Achtsteweg Zuid", "251"), "https://b-too.nl/")
                };

                hotspotTT.Businesses = businessesTT;
                hotspotRepository.Add(hotspotTT);

                Hotspot hotspotTR = new Hotspot("Hotspot TR", "De oude energiecentrale is getransformeerd zodat het geschikt is als kantoor- en atelierruimte.",
                   DateTime.Now,
                   new GeoCoordinates("5.4530481", "51.4494605"),
                   new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/EdPsYR8-Pck",
                   "Strijp Talk 18 - Dhr Brouwer", "Jaren actief geweest in gebouw TR, de toenmalige kolencentrale van Philips. Hier werden o.a. stoomturbines aangedreven om met die stoom de fabrieken van Philips van warmte te voorzien.", "Strijp-T"),
                   new AR360("path"));

                List<Business> businessesTR = new List<Business>() {
                new Business("Advies-en Ingenieursbureau Van de Laar B.V.", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31R"), "https://vandelaar.info/"),
                new Business("EAST / Starliciousfood", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31F"), "https://starliciousfood.nl/"),
                new Business("Franken Projectmanagement B.V.", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31S"), "https://bureaufranken.com/"),
                new Business("Louwerse Advocaten", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31K"), "https://advocatenkantoorlouwerse.nl/"),
                new Business("P33 Development B.V. (Amber)", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31D"), "https://driveamber.com"),
                new Business("Pycom LTD", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31B"), "https://pycom.io/"),
                new Business("Accenture", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31A"), "https://vanberloagency.com/"),
                new Business("WAES Brainport B.V.", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31N"), "https://www.wearewaes.com/"),
                new Business("Whyellow Innovators", new Address("Eindhoven", "5651CA", "Zwaanstraat", "31C"), "https://whyellow.nl/")
                };

                hotspotTR.Businesses = businessesTR;
                hotspotRepository.Add(hotspotTR);

                Hotspot hotspotTY = new Hotspot("Hotspot TY", "De 'Glaskathedraal' van Strijp-T. Dit iconische gebouw, de proeffabriek TY, onderdeel van het ontwikkelingscentrum voor glas.",
                   DateTime.Now,
                   new GeoCoordinates("5.4486910", "51.4534810"),
                   new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/39k814I55Mw",
                   "Strijp Talk - Rob Singels", "Werkzaam geweest in gebouw TY en samen met een hecht team zich bezig gehouden met ontwikkeling en productie van special glas voor TV schermen en TL verlichting.", "Strijp-T"),
                   new AR360("path"));

                List<Business> businessesTY = new List<Business>();

                hotspotTY.Businesses = businessesTY;
                hotspotRepository.Add(hotspotTY);

                Hotspot hotspotTZ = new Hotspot("Hotspot TZ", "De oude energiecentrale is getransformeerd zodat het geschikt is als kantoor- en atelierruimte.",
                   DateTime.Now,
                   new GeoCoordinates("5.4491126", "51.453097"),
                   new MovieInterviewDetails("Youtube", "https://www.youtube.com/embed/0AU8gGqVtBw",
                   "Talk 1 - Bets Christ Renting", "20 jaar bij Philips als koffiejuffrouw gewerkt in gebouw TQ en wat dat voor haar heeft betekend.", "Strijp-T"),
                   new AR360("path"));

                List<Business> businessesTZ = new List<Business>() {
                new Business("BZTRS. Agency B.V.", new Address("Eindhoven", "5651CA", "Achtsteweg Zuid", "241"), "https://bztrs.nl/"),
                new Business("CelSian Glass & Solar B.V", new Address("Eindhoven", "5651CA", "Achtsteweg Zuid", "241"), "https://www.celsian.nl/"),
                new Business("Enversed Projects", new Address("Eindhoven", "5651CA", "Achtsteweg Zuid", "241"), "https://www.enversed.com/"),
                new Business("StudentMovers", new Address("Eindhoven", "5651CA", "Achtsteweg Zuid", "241"), "https://www.studentmovers.nl/")
                };

                hotspotTZ.Businesses = businessesTZ;
                hotspotRepository.Add(hotspotTZ);

                hotspotRepository.Save();
            }

        }
    }
}
