namespace CMS.Services
{
    public class CountryService
    {
        public List<string> GetAllCountries()
        {
            var countries = new string[]
            {
                "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia",
                "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium",
                "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria",
                "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Canada", "Central African Republic", "Chad",
                "Chile", "China", "Colombia", "Comoros", "Congo", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic",
                "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor",
                "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Fiji",
                "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala",
                "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran",
                "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya",
                "Kiribati", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein",
                "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands",
                "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco",
                "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger",
                "Nigeria", "North Korea", "North Macedonia", "Norway", "Oman", "Pakistan", "Palau", "Panama",
                "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia",
                "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino",
                "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore",
                "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Korea", "South Sudan", "Spain",
                "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania",
                "Thailand", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda",
                "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu",
                "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe"
            };
            return countries.ToList();
        }

        public List<string> GetCountries(string name)
        {
            var countries = GetAllCountries();

            return countries.Where(x=> x.Contains(name, StringComparison.InvariantCulture)).ToList();
        }

        public List<String> GetAllStatesByCountryName(string countryName)
        {
            string[] states = [];
            switch (countryName)
            {
                case "Afghanistan":
                    states = new string[] { "Badakhshan", "Badghis", "Baghlan", "Balkh", "Bamyan", "Daykundi", "Farah", "Faryab", "Ghazni", "Ghor", "Helmand", "Herat", "Jowzjan", "Kabul", "Kandahar", "Kapisa", "Khost", "Kunar", "Kunduz", "Laghman", "Logar", "Nangarhar", "Nimroz", "Nuristan", "Paktia", "Paktika", "Panjshir", "Parwan", "Samangan", "Sar-e Pol", "Takhar", "Urozgan", "Wardak", "Zabul" };
                    break;
                case "Albania":
                    states = new string[] { "Berat", "Dibër", "Durrës", "Elbasan", "Fier", "Gjirokastër", "Korçë", "Kukës", "Lezhë", "Shkodër", "Tiranë", "Vlorë" };
                    break;
                case "Algeria":
                    states = new string[] { "Adrar", "Aïn Defla", "Aïn Témouchent", "Algiers", "Annaba", "Batna", "Béchar", "Béjaïa", "Biskra", "Blida", "Bordj Bou Arréridj", "Bouïra", "Boumerdès", "Chlef", "Constantine", "Djelfa", "El Bayadh", "El Oued", "El Tarf", "Ghardaïa", "Guelma", "Illizi", "Jijel", "Khenchela", "Laghouat", "M'Sila", "Mascara", "Médéa", "Mila", "Mostaganem", "Naâma", "Oran", "Ouargla", "Oum El Bouaghi", "Relizane", "Saïda", "Sétif", "Sidi Bel Abbès", "Skikda", "Souk Ahras", "Tamanrasset", "Tébessa", "Tiaret", "Tindouf", "Tipaza", "Tissemsilt", "Tizi Ouzou", "Tlemcen" };
                    break;
                case "Andorra":
                    states = new string[] { "Andorra la Vella", "Canillo", "Encamp", "Escaldes-Engordany", "La Massana", "Ordino", "Sant Julià de Lòria" };
                    break;
                case "Angola":
                    states = new string[] { "Bengo", "Benguela", "Bié", "Cabinda", "Cuando Cubango", "Cuanza Norte", "Cuanza Sul", "Cunene", "Huambo", "Huíla", "Luanda", "Lunda Norte", "Lunda Sul", "Malanje", "Moxico", "Namibe", "Uíge", "Zaire" };
                    break;
                case "Antigua and Barbuda":
                    states = new string[] { "Barbuda", "Redonda", "Saint George", "Saint John", "Saint Mary", "Saint Paul", "Saint Peter", "Saint Philip" };
                    break;
                case "Argentina":
                    states = new string[] { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Córdoba", "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego", "Tucumán" };
                    break;
                case "Armenia":
                    states = new string[] { "Aragatsotn", "Ararat", "Armavir", "Gegharkunik", "Kotayk", "Lori", "Shirak", "Syunik", "Tavush", "Vayots Dzor", "Yerevan" };
                    break;
                case "Australia":
                    states = new string[] { "Australian Capital Territory", "New South Wales", "Northern Territory", "Queensland", "South Australia", "Tasmania", "Victoria", "Western Australia" };
                    break;
                case "Austria":
                    states = new string[] { "Burgenland", "Carinthia", "Lower Austria", "Upper Austria", "Salzburg", "Styria", "Tyrol", "Vorarlberg", "Vienna" };
                    break;
                case "Azerbaijan":
                    states = new string[] { "Absheron", "Agdam", "Agdash", "Aghjabadi", "Agstafa", "Agsu", "Astara", "Babek", "Baku", "Balakan", "Barda", "Beylagan", "Bilasuvar", "Dashkasan", "Fizuli", "Ganja", "Gobustan", "Goranboy", "Goychay", "Goygol", "Hajigabul", "Imishli", "Ismailli", "Jabrayil", "Jalilabad", "Kalbajar", "Kangarli", "Khachmaz", "Khankendi", "Khojavend", "Kurdamir", "Lachin", "Lankaran", "Lankaran", "Lerik", "Masally", "Mingachevir", "Naftalan", "Nakhchivan", "Neftchala", "Oghuz", "Ordubad", "Qabala", "Qakh", "Qazakh", "Quba", "Qubadli", "Qusar", "Saatli", "Sabirabad", "Sadarak", "Salyan", "Shabran", "Shahbuz", "Shaki", "Shamakhi", "Shamkir", "Sharur", "Shirvan", "Siazan", "Sumqayit", "Tartar", "Tovuz", "Ujar", "Yardymli", "Yevlakh", "Zangilan", "Zaqatala", "Zardab" };
                    break;
                case "Bahamas":
                    states = new string[] { "Acklins", "Berry Islands", "Bimini", "Black Point", "Cat Island", "Central Abaco", "Central Andros", "Central Eleuthera", "Crooked Island and Long Cay", "East Grand Bahama", "Exuma", "Grand Cay", "Harbour Island", "Hope Town", "Inagua", "Long Island", "Mangrove Cay", "Mayaguana", "Moore’s Island", "New Providence", "North Abaco", "North Andros", "North Eleuthera", "Ragged Island", "Rum Cay", "San Salvador", "South Abaco", "South Andros", "South Eleuthera", "Spanish Wells", "West Grand Bahama" };
                    break;
                case "Bahrain":
                    states = new string[] { "Capital Governorate", "Central Governorate", "Muharraq Governorate", "Northern Governorate", "Southern Governorate" };
                    break;
                case "Bangladesh":
                    states = new string[] { "Barisal", "Chattogram", "Dhaka", "Khulna", "Mymensingh", "Rajshahi", "Rangpur", "Sylhet" };
                    break;
                case "Barbados":
                    states = new string[] { "Christ Church", "Saint Andrew", "Saint George", "Saint James", "Saint John", "Saint Joseph", "Saint Lucy", "Saint Michael", "Saint Peter", "Saint Philip", "Saint Thomas" };
                    break;
                case "Belarus":
                    states = new string[] { "Brest Region", "Gomel Region", "Grodno Region", "Minsk Region", "Mogilev Region", "Vitebsk Region" };
                    break;
                case "Belgium":
                    states = new string[] { "Antwerp", "East Flanders", "Flemish Brabant", "Hainaut", "Liège", "Limburg", "Luxembourg", "Namur", "Walloon Brabant", "West Flanders", "Brussels-Capital Region" };
                    break;
                case "Belize":
                    states = new string[] { "Belize District", "Cayo District", "Corozal District", "Orange Walk District", "Stann Creek District", "Toledo District" };
                    break;
                case "Benin":
                    states = new string[] { "Alibori", "Atakora", "Atlantique", "Borgou", "Collines", "Donga", "Kouffo", "Littoral", "Mono", "Ouémé", "Plateau", "Zou" };
                    break;
                case "Bhutan":
                    states = new string[] { "Bumthang", "Chukha", "Dagana", "Gasa", "Haa", "Lhuntse", "Mongar", "Paro", "Pema Gatshel", "Punakha", "Samdrup Jongkhar", "Samtse", "Sarpang", "Thimphu", "Trashigang", "Trashiyangtse", "Trongsa", "Tsirang", "Wangdue Phodrang", "Zhemgang" };
                    break;
                case "Bolivia":
                    states = new string[] { "Beni", "Chuquisaca", "Cochabamba", "La Paz", "Oruro", "Pando", "Potosí", "Santa Cruz", "Tarija" };
                    break;
                case "Bosnia and Herzegovina":
                    states = new string[] { "Una-Sana Canton", "Posavina Canton", "Tuzla Canton", "Zenica-Doboj Canton", "Bosnian Podrinje Canton", "Central Bosnia Canton", "Herzegovina-Neretva Canton", "West Herzegovina Canton", "Sarajevo Canton", "West Bosnia Canton", "Herzegovina-Neretva Canton", "West Herzegovina Canton", "Sarajevo Canton", "Canton 10" };
                    break;
                case "Botswana":
                    states = new string[] { "Central", "Chobe", "Ghanzi", "Kgalagadi", "Kgatleng", "Kweneng", "North-East", "North-West", "South-East", "Southern" };
                    break;
                case "Brazil":
                    states = new string[] { "Acre", "Alagoas", "Amapá", "Amazonas", "Bahia", "Ceará", "Distrito Federal", "Espírito Santo", "Goiás", "Maranhão", "Mato Grosso", "Mato Grosso do Sul", "Minas Gerais", "Pará", "Paraíba", "Paraná", "Pernambuco", "Piauí", "Rio de Janeiro", "Rio Grande do Norte", "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina", "São Paulo", "Sergipe", "Tocantins" };
                    break;
                case "Brunei":
                    states = new string[] { "Belait", "Brunei-Muara", "Temburong", "Tutong" };
                    break;
                case "Bulgaria":
                    states = new string[] { "Blagoevgrad", "Burgas", "Dobrich", "Gabrovo", "Haskovo", "Kardzhali", "Kyustendil", "Lovech", "Montana", "Pazardzhik", "Pernik", "Pleven", "Plovdiv", "Razgrad", "Ruse", "Shumen", "Silistra", "Sliven", "Smolyan", "Sofia", "Sofia-Grad", "Stara Zagora", "Targovishte", "Varna", "Veliko Tarnovo", "Vidin", "Vratsa", "Yambol" };
                    break;
                case "Burkina Faso":
                    states = new string[] { "Balé", "Bam", "Banwa", "Bazèga", "Boucle du Mouhoun", "Cascades", "Centre", "Centre-Est", "Centre-Nord", "Centre-Ouest", "Centre-Sud", "Comoé", "Est", "Ganzourgou", "Gnagna", "Gourma", "Houet", "Ioba", "Kadiogo", "Kénédougou", "Komondjari", "Kompienga", "Kossi", "Koulpélogo", "Kouritenga", "Kourwéogo", "Léraba", "Loroum", "Mouhoun", "Nahouri", "Namentenga", "Nayala", "Noumbiel", "Oubritenga", "Oudalan", "Passoré", "Poni", "Sahel", "Sanguié", "Sanmatenga", "Séno", "Sissili", "Soum", "Sourou", "Tapoa", "Tuy" };
                    break;
                case "Burundi":
                    states = new string[] { "Bubanza", "Bujumbura Mairie", "Bujumbura Rural", "Bururi", "Cankuzo", "Cibitoke", "Gitega", "Karuzi", "Kayanza", "Kirundo", "Makamba", "Muramvya", "Muyinga", "Mwaro", "Ngozi", "Rumonge", "Rutana", "Ruyigi" };
                    break;
                case "Cabo Verde":
                    states = new string[] { "Boa Vista", "Brava", "Maio", "Mosteiros", "Paul", "Porto Novo", "Praia", "Ribeira Brava", "Ribeira Grande", "Ribeira Grande de Santiago", "Sal", "Santa Catarina", "Santa Catarina do Fogo", "Santa Cruz", "São Domingos", "São Filipe", "São Lourenço dos Órgãos", "São Miguel", "São Salvador do Mundo", "São Vicente", "Tarrafal", "Tarrafal de São Nicolau" };
                    break;
                case "Cambodia":
                    states = new string[] { "Banteay Meanchey", "Battambang", "Kampong Cham", "Kampong Chhnang", "Kampong Speu", "Kampong Thom", "Kampot", "Kandal", "Kep", "Koh Kong", "Kratié", "Mondulkiri", "Oddar Meanchey", "Pailin", "Phnom Penh", "Preah Sihanouk", "Preah Vihear", "Pursat", "Ratanakiri", "Siem Reap", "Stung Treng", "Svay Rieng", "Takéo", "Tboung Khmum" };
                    break;
                case "Cameroon":
                    states = new string[] { "Adamaoua", "Centre", "East", "Far North", "Littoral", "North", "Northwest", "South", "Southwest", "West" };
                    break;
                case "Canada":
                    states = new string[] { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan" };
                    break;
                case "Central African Republic":
                    states = new string[] { "Bamingui-Bangoran", "Bangui", "Basse-Kotto", "Haut-Mbomou", "Haute-Kotto", "Kémo", "Lobaye", "Mambéré-Kadéï", "Mbomou", "Nana-Grébizi", "Nana-Mambéré", "Ombella-M'Poko", "Ouaka", "Ouham", "Ouham-Pendé", "Sangha-Mbaéré", "Vakaga" };
                    break;
                case "Chad":
                    states = new string[] { "Bahr el Gazel", "Batha", "Borkou", "Ennedi-Est", "Ennedi-Ouest", "Guéra", "Hadjer-Lamis", "Kanem", "Lac", "Logone Occidental", "Logone Oriental", "Mandoul", "Mayo-Kebbi Est", "Mayo-Kebbi Ouest", "Moyen-Chari", "N'Djamena", "Ouaddaï", "Salamat", "Sila", "Tandjilé", "Tibesti", "Wadi Fira" };
                    break;
                case "Chile":
                    states = new string[] { "Aisén del General Carlos Ibáñez del Campo", "Antofagasta", "Araucanía", "Arica y Parinacota", "Atacama", "Biobío", "Coquimbo", "Los Lagos", "Los Ríos", "Magallanes y de la Antártica Chilena", "Maule", "Ñuble", "O'Higgins", "Región Metropolitana de Santiago", "Tarapacá", "Valparaíso" };
                    break;
                case "China":
                    states = new string[] { "Anhui", "Beijing", "Chongqing", "Fujian", "Gansu", "Guangdong", "Guangxi", "Guizhou", "Hainan", "Hebei", "Heilongjiang", "Henan", "Hubei", "Hunan", "Inner Mongolia", "Jiangsu", "Jiangxi", "Jilin", "Liaoning", "Ningxia", "Qinghai", "Shaanxi", "Shandong", "Shanghai", "Shanxi", "Sichuan", "Tianjin", "Tibet", "Xinjiang", "Yunnan", "Zhejiang" };
                    break;
                case "Colombia":
                    states = new string[] { "Amazonas", "Antioquia", "Arauca", "Atlántico", "Bolívar", "Boyacá", "Caldas", "Caquetá", "Casanare", "Cauca", "Cesar", "Chocó", "Córdoba", "Cundinamarca", "Guainía", "Guaviare", "Huila", "La Guajira", "Magdalena", "Meta", "Nariño", "Norte de Santander", "Putumayo", "Quindío", "Risaralda", "San Andrés y Providencia", "Santander", "Sucre", "Tolima", "Valle del Cauca", "Vaupés", "Vichada" };
                    break;
                case "Comoros":
                    states = new string[] { "Anjouan", "Grande Comore", "Mohéli" };
                    break;
                case "Congo":
                    states = new string[] { "Bouenza", "Brazzaville", "Cuvette", "Cuvette-Ouest", "Kouilou", "Lékoumou", "Likouala", "Niari", "Plateaux", "Pointe-Noire", "Pool", "Sangha" };
                    break;
                case "Costa Rica":
                    states = new string[] { "Alajuela", "Cartago", "Guanacaste", "Heredia", "Limón", "Puntarenas", "San José" };
                    break;
                case "Croatia":
                    states = new string[] { "Bjelovar-Bilogora", "Brod-Posavina", "Dubrovnik-Neretva", "Istria", "Karlovac", "Koprivnica-Križevci", "Krapina-Zagorje", "Lika-Senj", "Međimurje", "Osijek-Baranja", "Požega-Slavonia", "Primorje-Gorski Kotar", "Šibenik-Knin", "Sisak-Moslavina", "Split-Dalmatia", "Varaždin", "Virovitica-Podravina", "Vukovar-Syrmia", "Zadar", "Zagreb", "Zagreb County" };
                    break;
                case "Cuba":
                    states = new string[] { "Artemisa", "Camagüey", "Ciego de Ávila", "Cienfuegos", "Granma", "Guantánamo", "Holguín", "Isla de la Juventud", "La Habana", "Las Tunas", "Matanzas", "Mayabeque", "Pinar del Río", "Sancti Spíritus", "Santiago de Cuba", "Villa Clara" };
                    break;
                case "Cyprus":
                    states = new string[] { "Famagusta", "Kyrenia", "Larnaca", "Limassol", "Nicosia", "Paphos" };
                    break;
                case "Czech Republic":
                    states = new string[] { "Central Bohemian Region", "Hradec Králové Region", "Karlovy Vary Region", "Liberec Region", "Moravian-Silesian Region", "Olomouc Region", "Pardubice Region", "Plzeň Region", "Prague", "South Bohemian Region", "South Moravian Region", "Ústí nad Labem Region", "Vysočina Region", "Zlín Region" };
                    break;
                case "Democratic Republic of the Congo":
                    states = new string[] { "Bas-Uele", "Équateur", "Haut-Katanga", "Haut-Lomami", "Haut-Uele", "Ituri", "Kasaï", "Kasaï-Central", "Kasaï-Oriental", "Kinshasa", "Kongo-Central", "Kwango", "Kwilu", "Lomami", "Lualaba", "Mai-Ndombe", "Maniema", "Mongala", "Nord-Kivu", "Nord-Ubangi", "Sankuru", "Sud-Kivu", "Sud-Ubangi", "Tanganyika", "Tshopo", "Tshuapa" };
                    break;
                case "Denmark":
                    states = new string[] { "Capital Region of Denmark", "Central Denmark Region", "North Denmark Region", "Region of Southern Denmark" };
                    break;
                case "Djibouti":
                    states = new string[] { "Ali Sabieh", "Arta", "Dikhil", "Djibouti", "Obock", "Tadjourah" };
                    break;
                case "Dominica":
                    states = new string[] { "Saint Andrew Parish", "Saint David Parish", "Saint George Parish", "Saint John Parish", "Saint Joseph Parish", "Saint Luke Parish", "Saint Mark Parish", "Saint Patrick Parish", "Saint Paul Parish", "Saint Peter Parish" };
                    break;
                case "Dominican Republic":
                    states = new string[] { "Azua", "Baoruco", "Barahona", "Dajabón", "Distrito Nacional", "Duarte", "Elías Piña", "El Seibo", "Espaillat", "Hato Mayor", "Hermanas Mirabal", "Independencia", "La Altagracia", "La Romana", "La Vega", "María Trinidad Sánchez", "Monseñor Nouel", "Monte Cristi", "Monte Plata", "Pedernales", "Peravia", "Puerto Plata", "Samaná", "Sánchez Ramírez", "San Cristóbal", "San José de Ocoa", "San Juan", "San Pedro de Macorís", "Santiago", "Santiago Rodríguez", "Santo Domingo", "Valverde" };
                    break;
                case "East Timor":
                    states = new string[] { "Aileu", "Ainaro", "Baucau", "Bobonaro", "Cova Lima", "Dili", "Ermera", "Lautém", "Liquiçá", "Manatuto", "Manufahi", "Oecusse", "Viqueque" };
                    break;
                case "Ecuador":
                    states = new string[] { "Azuay", "Bolívar", "Cañar", "Carchi", "Chimborazo", "Cotopaxi", "El Oro", "Esmeraldas", "Galápagos", "Guayas", "Imbabura", "Loja", "Los Ríos", "Manabí", "Morona-Santiago", "Napo", "Orellana", "Pastaza", "Pichincha", "Santa Elena", "Santo Domingo de los Tsáchilas", "Sucumbíos", "Tungurahua", "Zamora-Chinchipe" };
                    break;
                case "Egypt":
                    states = new string[] { "Alexandria", "Aswan", "Asyut", "Beheira", "Beni Suef", "Cairo", "Dakahlia", "Damietta", "Faiyum", "Gharbia", "Giza", "Ismailia", "Kafr el-Sheikh", "Luxor", "Matrouh", "Minya", "Monufia", "New Valley", "North Sinai", "Port Said", "Qalyubia", "Qena", "Red Sea", "Sharqia", "Sohag", "South Sinai", "Suez" };
                    break;
                case "El Salvador":
                    states = new string[] { "Ahuachapán", "Cabañas", "Chalatenango", "Cuscatlán", "La Libertad", "La Paz", "La Unión", "Morazán", "San Miguel", "San Salvador", "San Vicente", "Santa Ana", "Sonsonate", "Usulután" };
                    break;
                case "Equatorial Guinea":
                    states = new string[] { "Annobón", "Bioko Norte", "Bioko Sur", "Centro Sur", "Kié-Ntem", "Litoral", "Wele-Nzas" };
                    break;
                case "Eritrea":
                    states = new string[] { "Anseba", "Debub", "Debubawi Keyih Bahri", "Gash-Barka", "Maekel", "Semienawi Keyih Bahri" };
                    break;
                case "Estonia":
                    states = new string[] { "Harju", "Hiiu", "Ida-Viru", "Jõgeva", "Järva", "Lääne", "Lääne-Viru", "Põlva", "Pärnu", "Rapla", "Saare", "Tartu", "Valga", "Viljandi", "Võru" };
                    break;
                case "Eswatini":
                    states = new string[] { "Hhohho", "Lubombo", "Manzini", "Shiselweni" };
                    break;
                case "Ethiopia":
                    states = new string[] { "Addis Ababa", "Afar", "Amhara", "Benishangul-Gumuz", "Dire Dawa", "Gambela", "Harari", "Oromia", "Sidama", "Somali", "Southern Nations, Nationalities, and Peoples' Region", "Tigray" };
                    break;
                case "Fiji":
                    states = new string[] { "Central Division", "Eastern Division", "Northern Division", "Rotuma", "Western Division" };
                    break;
                case "Finland":
                    states = new string[] { "Åland Islands", "Central Finland", "Central Ostrobothnia", "Eastern Finland", "Finland Proper", "Kainuu", "Kymenlaakso", "Lapland", "North Karelia", "Northern Ostrobothnia", "Northern Savonia", "Ostrobothnia", "Päijänne Tavastia", "Pirkanmaa", "Satakunta", "South Karelia", "Southern Ostrobothnia", "Southern Savonia", "Tavastia Proper", "Uusimaa" };
                    break;
                case "France":
                    states = new string[] { "Auvergne-Rhône-Alpes", "Bourgogne-Franche-Comté", "Brittany", "Centre-Val de Loire", "Corsica", "Grand Est", "Hauts-de-France", "Île-de-France", "Normandy", "Nouvelle-Aquitaine", "Occitanie", "Pays de la Loire", "Provence-Alpes-Côte d'Azur" };
                    break;
                case "Gabon":
                    states = new string[] { "Estuaire", "Haut-Ogooué", "Moyen-Ogooué", "Ngounié", "Nyanga", "Ogooué-Ivindo", "Ogooué-Lolo", "Ogooué-Maritime", "Woleu-Ntem" };
                    break;
                case "Gambia":
                    states = new string[] { "Banjul", "Central River", "Lower River", "North Bank", "Upper River", "West Coast" };
                    break;
                case "Georgia":
                    states = new string[] { "Adjara", "Guria", "Imereti", "Kakheti", "Kvemo Kartli", "Mtskheta-Mtianeti", "Racha-Lechkhumi and Kvemo Svaneti", "Samegrelo-Zemo Svaneti", "Samtskhe-Javakheti", "Shida Kartli", "Tbilisi" };
                    break;
                case "Germany":
                    states = new string[] { "Baden-Württemberg", "Bavaria", "Berlin", "Brandenburg", "Bremen", "Hamburg", "Hesse", "Lower Saxony", "Mecklenburg-Vorpommern", "North Rhine-Westphalia", "Rhineland-Palatinate", "Saarland", "Saxony", "Saxony-Anhalt", "Schleswig-Holstein", "Thuringia" };
                    break;
                case "Ghana":
                    states = new string[] { "Ahafo", "Ashanti", "Bono", "Bono East", "Central", "Eastern", "Greater Accra", "Northern", "North East", "Oti", "Savannah", "Upper East", "Upper West", "Volta", "Western", "Western North" };
                    break;
                case "Greece":
                    states = new string[] { "Attica", "Central Greece", "Central Macedonia", "Crete", "Eastern Macedonia and Thrace", "Epirus", "Ionian Islands", "Mount Athos", "North Aegean", "Peloponnese", "South Aegean", "Thessaly", "Western Greece", "Western Macedonia" };
                    break;
                case "Grenada":
                    states = new string[] { "Carriacou and Petite Martinique", "Saint Andrew", "Saint David", "Saint George", "Saint John", "Saint Mark", "Saint Patrick" };
                    break;
                case "Guatemala":
                    states = new string[] { "Alta Verapaz", "Baja Verapaz", "Chimaltenango", "Chiquimula", "El Progreso", "Escuintla", "Guatemala", "Huehuetenango", "Izabal", "Jalapa", "Jutiapa", "Petén", "Quetzaltenango", "Quiché", "Retalhuleu", "Sacatepéquez", "San Marcos", "Santa Rosa", "Sololá", "Suchitepéquez", "Totonicapán", "Zacapa" };
                    break;
                case "Guinea":
                    states = new string[] { "Boké", "Conakry", "Faranah", "Kankan", "Kindia", "Labé", "Mamou", "Nzérékoré" };
                    break;
                case "Guinea-Bissau":
                    states = new string[] { "Bafatá", "Biombo", "Bissau", "Bolama-Bijagos", "Cacheu", "Gabú", "Oio", "Quinara", "Tombali" };
                    break;
                case "Guyana":
                    states = new string[] { "Barima-Waini", "Cuyuni-Mazaruni", "Demerara-Mahaica", "East Berbice-Corentyne", "Essequibo Islands-West Demerara", "Mahaica-Berbice", "Pomeroon-Supenaam", "Potaro-Siparuni", "Upper Demerara-Berbice", "Upper Takutu-Upper Essequibo" };
                    break;
                case "Haiti":
                    states = new string[] { "Artibonite", "Centre", "Grand'Anse", "Nippes", "Nord", "Nord-Est", "Nord-Ouest", "Ouest", "Sud", "Sud-Est" };
                    break;
                case "Honduras":
                    states = new string[] { "Atlántida", "Choluteca", "Colón", "Comayagua", "Copán", "Cortés", "El Paraíso", "Francisco Morazán", "Gracias a Dios", "Intibucá", "Islas de la Bahía", "La Paz", "Lempira", "Ocotepeque", "Olancho", "Santa Bárbara", "Valle", "Yoro" };
                    break;
                case "Hungary":
                    states = new string[] { "Bács-Kiskun", "Baranya", "Békés", "Borsod-Abaúj-Zemplén", "Csongrád", "Fejér", "Győr-Moson-Sopron", "Hajdú-Bihar", "Heves", "Jász-Nagykun-Szolnok", "Komárom-Esztergom", "Nógrád", "Pest", "Somogy", "Szabolcs-Szatmár-Bereg", "Tolna", "Vas", "Veszprém", "Zala" };
                    break;
                case "Iceland":
                    states = new string[] { "Capital Region", "Northeastern Region", "Northwestern Region", "Southern Peninsula", "Southern Region", "Western Region", "Westfjords" };
                    break;
                case "India":
                    states = new string[] { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli and Daman and Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Ladakh", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal" };
                    break;
                case "Indonesia":
                    states = new string[] { "Aceh", "Bali", "Bangka Belitung Islands", "Banten", "Bengkulu", "Central Java", "Central Kalimantan", "Central Sulawesi", "East Java", "East Kalimantan", "East Nusa Tenggara", "Gorontalo", "Jakarta", "Jambi", "Lampung", "Maluku", "North Kalimantan", "North Maluku", "North Sulawesi", "North Sumatra", "Papua", "Riau", "Riau Islands", "South Kalimantan", "South Sulawesi", "South Sumatra", "Southeast Sulawesi", "West Java", "West Kalimantan", "West Nusa Tenggara", "West Papua", "West Sulawesi", "West Sumatra", "Yogyakarta" };
                    break;
                case "Iran":
                    states = new string[] { "Alborz", "Ardabil", "Bushehr", "Chaharmahal and Bakhtiari", "East Azerbaijan", "Isfahan", "Fars", "Gilan", "Golestan", "Hamadan", "Hormozgan", "Ilam", "Kerman", "Kermanshah", "Khuzestan", "Kohgiluyeh and Boyer-Ahmad", "Kurdistan", "Lorestan", "Markazi", "Mazandaran", "North Khorasan", "Qazvin", "Qom", "Razavi Khorasan", "Semnan", "Sistan and Baluchestan", "South Khorasan", "Tehran", "West Azerbaijan", "Yazd", "Zanjan" };
                    break;
                case "Iraq":
                    states = new string[] { "Al Anbar", "Babylon", "Baghdad", "Basra", "Dhi Qar", "Diyala", "Dohuk", "Erbil", "Karbala", "Kirkuk", "Maysan", "Muthanna", "Najaf", "Nineveh", "Saladin", "Sulaymaniyah", "Wasit" };
                    break;
                case "Ireland":
                    states = new string[] { "Carlow", "Cavan", "Clare", "Cork", "Donegal", "Dublin", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Waterford", "Westmeath", "Wexford", "Wicklow" };
                    break;
                case "Israel":
                    states = new string[] { "Central District", "Haifa District", "Jerusalem District", "Northern District", "Southern District", "Tel Aviv District" };
                    break;
                case "Italy":
                    states = new string[] { "Abruzzo", "Aosta Valley", "Apulia", "Basilicata", "Calabria", "Campania", "Emilia-Romagna", "Friuli Venezia Giulia", "Lazio", "Liguria", "Lombardy", "Marche", "Molise", "Piedmont", "Sardinia", "Sicily", "Trentino-South Tyrol", "Tuscany", "Umbria", "Veneto" };
                    break;
                case "Ivory Coast":
                    states = new string[] { "Abidjan", "Bas-Sassandra", "Comoé", "Denguélé", "Gôh-Djiboua", "Lacs", "Lagunes", "Montagnes", "Sassandra-Marahoué", "Savanes", "Vallée du Bandama", "Woroba", "Yamoussoukro", "Zanzan" };
                    break;
                case "Jamaica":
                    states = new string[] { "Clarendon", "Hanover", "Kingston", "Manchester", "Portland", "Saint Andrew", "Saint Ann", "Saint Catherine", "Saint Elizabeth", "Saint James", "Saint Mary", "Saint Thomas", "Trelawny", "Westmoreland" };
                    break;
                case "Japan":
                    states = new string[] { "Aichi", "Akita", "Aomori", "Chiba", "Ehime", "Fukui", "Fukuoka", "Fukushima", "Gifu", "Gunma", "Hiroshima", "Hokkaido", "Hyogo", "Ibaraki", "Ishikawa", "Iwate", "Kagawa", "Kagoshima", "Kanagawa", "Kochi", "Kumamoto", "Kyoto", "Mie", "Miyagi", "Miyazaki", "Nagano", "Nagasaki", "Nara", "Niigata", "Oita", "Okayama", "Okinawa", "Osaka", "Saga", "Saitama", "Shiga", "Shimane", "Shizuoka", "Tochigi", "Tokushima", "Tokyo", "Tottori", "Toyama", "Wakayama", "Yamagata", "Yamaguchi", "Yamanashi" };
                    break;
                case "Jordan":
                    states = new string[] { "Ajloun", "Amman", "Aqaba", "Balqa", "Irbid", "Jerash", "Karak", "Ma'an", "Madaba", "Mafraq", "Tafilah", "Zarqa" };
                    break;
                case "Kazakhstan":
                    states = new string[] { "Akmola", "Aktobe", "Almaty", "Atyrau", "East Kazakhstan", "Jambyl", "Karaganda", "Kostanay", "Kyzylorda", "Mangystau", "North Kazakhstan", "Nur-Sultan", "Pavlodar", "Shymkent", "Turkestan", "West Kazakhstan" };
                    break;
                case "Kenya":
                    states = new string[] { "Baringo", "Bomet", "Bungoma", "Busia", "Elgeyo-Marakwet", "Embu", "Garissa", "Homa Bay", "Isiolo", "Kajiado", "Kakamega", "Kericho", "Kiambu", "Kilifi", "Kirinyaga", "Kisii", "Kisumu", "Kitui", "Kwale", "Laikipia", "Lamu", "Machakos", "Makueni", "Mandera", "Marsabit", "Meru", "Migori", "Mombasa", "Murang'a", "Nairobi", "Nakuru", "Nandi", "Narok", "Nyamira", "Nyandarua", "Nyeri", "Samburu", "Siaya", "Taita-Taveta", "Tana River", "Tharaka-Nithi", "Trans-Nzoia", "Turkana", "Uasin Gishu", "Vihiga", "Wajir", "West Pokot" };
                    break;
                case "Kiribati":
                    states = new string[] { "Gilbert Islands", "Line Islands", "Phoenix Islands" };
                    break;
                case "Kuwait":
                    states = new string[] { "Al Ahmadi", "Al Farwaniyah", "Al Jahra", "Capital Governorate", "Hawalli", "Mubarak Al-Kabeer" };
                    break;
                case "Kyrgyzstan":
                    states = new string[] { "Batken", "Bishkek", "Chuy", "Issyk-Kul", "Jalal-Abad", "Naryn", "Osh", "Talas", "Ysyk-Köl" };
                    break;
                case "Laos":
                    states = new string[] { "Attapeu", "Bokeo", "Bolikhamsai", "Champasak", "Houaphanh", "Khammouane", "Luang Namtha", "Luang Prabang", "Oudomxay", "Phongsaly", "Sainyabuli", "Salavan", "Savannakhet", "Sekong", "Vientiane Province", "Vientiane Capital", "Xaisomboun", "Xekong", "Xiangkhouang" };
                    break;
                case "Latvia":
                    states = new string[] { "Aglona", "Aizkraukle", "Aizpute", "Aknīste", "Aloja", "Alsunga", "Alūksne", "Amata", "Ape", "Auce", "Ādaži", "Babīte", "Baldone", "Baltinava", "Balvi", "Bauska", "Beverīna", "Brocēni", "Burtnieki", "Carnikava", "Cēsis", "Cesvaine", "Cibla", "Dagda", "Daugavpils", "Dobele", "Dundaga", "Durbe", "Engure", "Ērgļi", "Garkalne", "Grobiņa", "Gulbene", "Iecava", "Ikšķile", "Ilūkste", "Inčukalns", "Jaunjelgava", "Jaunpiebalga", "Jaunpils", "Jelgava", "Jēkabpils", "Kandava", "Kārsava", "Ķegums", "Ķekava", "Kocēni", "Koknese", "Krāslava", "Krimulda", "Krustpils", "Kuldīga", "Lielvārde", "Liepāja", "Līgatne", "Limbaži", "Līvāni", "Lubāna", "Ludza", "Madona", "Mālpils", "Mārupe", "Mazsalaca", "Mērsrags", "Naukšēni", "Nereta", "Nīca", "Ogre", "Olaine", "Ozolnieki", "Pārgauja", "Pāvilosta", "Pļaviņas", "Preiļi", "Priekule", "Priekuļi", "Rauna", "Rēzekne", "Riebiņi", "Riga", "Rojas", "Ropaži", "Rucava", "Rugāji", "Rundāle", "Sabile", "Salacgrīva", "Salaspils", "Saldus", "Saulkrasti", "Sēja", "Sigulda", "Skrīveri", "Skrunda", "Smiltene", "Stopiņi", "Strenči", "Talsi", "Tērvete", "Tukums", "Vaiņode", "Valka", "Valmiera", "Varakļāni", "Vārkava", "Vecpiebalga", "Vecumnieki", "Ventspils", "Viesīte", "Viļaka", "Viļāni", "Zilupe" };
                    break;
                case "Lebanon":
                    states = new string[] { "Akkar", "Baalbek-Hermel", "Beirut", "Beqaa", "Mount Lebanon", "Nabatieh", "North Governorate", "South Governorate" };
                    break;
                case "Lesotho":
                    states = new string[] { "Berea", "Butha-Buthe", "Leribe", "Mafeteng", "Maseru", "Mohale's Hoek", "Mokhotlong", "Qacha's Nek", "Quthing", "Thaba-Tseka" };
                    break;
                case "Liberia":
                    states = new string[] { "Bomi", "Bong", "Gbarpolu", "Grand Bassa", "Grand Cape Mount", "Grand Gedeh", "Grand Kru", "Lofa", "Margibi", "Maryland", "Montserrado", "Nimba", "River Cess", "River Gee", "Sinoe" };
                    break;
                case "Libya":
                    states = new string[] { "Al Wahat", "Benghazi", "Derna", "Ghat", "Jabal al Akhdar", "Jabal al Gharbi", "Jafara", "Jufra", "Kufra", "Marj", "Misrata", "Murqub", "Murzuq", "Nalut", "Nuqat al Khams", "Sabha", "Sirte", "Tripoli", "Wadi al Hayaa", "Wadi al Shatii", "Zawiya" };
                    break;
                case "Liechtenstein":
                    states = new string[] { "Balzers", "Eschen", "Gamprin", "Mauren", "Planken", "Ruggell", "Schaan", "Schellenberg", "Triesen", "Triesenberg", "Vaduz" };
                    break;
                case "Lithuania":
                    states = new string[] { "Alytus", "Birštonas", "Druskininkai", "Elektrėnai", "Ignalina", "Jonava", "Joniškis", "Jurbarkas", "Kaišiadorys", "Kalvarija", "Kaunas", "Kazlų Rūda", "Kėdainiai", "Kelmė", "Klaipėda", "Kretinga", "Kupiškis", "Lazdijai", "Marijampolė", "Mažeikiai", "Molėtai", "Neringa", "Pagėgiai", "Pakruojis", "Palanga", "Panevėžys", "Pasvalys", "Plungė", "Prienai", "Radviliškis", "Raseiniai", "Rietavas", "Rokiškis", "Šakiai", "Šalčininkai", "Šiauliai", "Šilalė", "Šilutė", "Širvintos", "Skuodas", "Švenčionys", "Tauragė", "Telšiai", "Trakai", "Ukmergė", "Utena", "Varėna", "Vilkaviškis", "Vilnius", "Visaginas", "Zarasai" };
                    break;
                case "Luxembourg":
                    states = new string[] { "Clervaux", "Diekirch", "Echternach", "Esch-sur-Alzette", "Grevenmacher", "Luxembourg", "Mersch", "Redange", "Remich", "Vianden", "Wiltz" };
                    break;
                case "Madagascar":
                    states = new string[] { "Antananarivo", "Antsiranana", "Fianarantsoa", "Mahajanga", "Toamasina", "Toliara" };
                    break;
                case "Malawi":
                    states = new string[] { "Balaka", "Blantyre", "Chikwawa", "Chiradzulu", "Chitipa", "Dedza", "Dowa", "Karonga", "Kasungu", "Likoma", "Lilongwe", "Machinga", "Mangochi", "Mchinji", "Mulanje", "Mwanza", "Mzimba", "Nkhata Bay", "Nkhotakota", "Nsanje", "Ntcheu", "Ntchisi", "Phalombe", "Rumphi", "Salima", "Thyolo", "Zomba" };
                    break;
                case "Malaysia":
                    states = new string[] { "Johor", "Kedah", "Kelantan", "Kuala Lumpur", "Labuan", "Melaka", "Negeri Sembilan", "Pahang", "Perak", "Perlis", "Penang", "Putrajaya", "Sabah", "Sarawak", "Selangor", "Terengganu" };
                    break;
                case "Maldives":
                    states = new string[] { "Alifu", "Baa", "Dhaalu", "Faafu", "Gaafu Alifu", "Gaafu Dhaalu", "Gnaviyani", "Haa Alifu", "Haa Dhaalu", "Kaafu", "Laamu", "Lhaviyani", "Male", "Meemu", "Noonu", "Raa", "Seenu", "Shaviyani", "Thaa", "Vaavu" };
                    break;
                case "Mali":
                    states = new string[] { "Bamako", "Gao", "Kayes", "Kidal", "Koulikoro", "Mopti", "Ségou", "Sikasso", "Tombouctou" };
                    break;
                case "Malta":
                    states = new string[] { "Attard", "Balzan", "Birgu", "Birkirkara", "Birżebbuġa", "Bormla", "Dingli", "Fgura", "Floriana", "Fontana", "Għajnsielem", "Għarb", "Għargħur", "Għasri", "Għaxaq", "Gżira", "Gudja", "Gżira", "Ħamrun", "Iklin", "Isla", "Kalkara", "Kerċem", "Kirkop", "Lija", "Luqa", "Marsa", "Marsaskala", "Marsaxlokk", "Mdina", "Mellieħa", "Mġarr", "Mosta", "Mqabba", "Msida", "Mtarfa", "Munxar", "Nadur", "Naxxar", "Paola", "Pembroke", "Pietà", "Qala", "Qormi", "Qrendi", "Rabat", "Safi", "San Ġiljan", "San Ġwann", "San Lawrenz", "Sannat", "Santa Luċija", "Santa Venera", "Siġġiewi", "Sliema", "St. Julian's", "St. Paul's Bay", "Swieqi", "Ta' Xbiex", "Tarxien", "Valletta", "Xagħra", "Xewkija", "Xgħajra", "Żabbar", "Żebbuġ", "Żebbuġ", "Żejtun", "Żurrieq" };
                    break;
                case "Marshall Islands":
                    states = new string[] { "Ailinglaplap", "Ailuk", "Arno", "Aur", "Bikini", "Ebon", "Enewetak", "Jabat", "Jaluit", "Kili", "Kwajalein", "Lae", "Lib", "Likiep", "Majuro", "Maloelap", "Mejit", "Mili", "Namdrik", "Namu", "Rongelap", "Rongrik", "Toke", "Ujae", "Ujelang", "Utrik", "Wotho", "Wotje" };
                    break;
                case "Mauritania":
                    states = new string[] { "Adrar", "Assaba", "Brakna", "Dakhlet Nouadhibou", "Gorgol", "Guidimaka", "Hodh Ech Chargui", "Hodh El Gharbi", "Inchiri", "Nouakchott", "Tagant", "Tiris Zemmour", "Trarza" };
                    break;
                case "Mauritius":
                    states = new string[] { "Agalega Islands", "Beau Bassin-Rose Hill", "Cargados Carajos Shoals (Saint Brandon)", "Flacq", "Grand Port", "Moka", "Pamplemousses", "Plaines Wilhems", "Port Louis", "Quatre Bornes", "Rivière du Rempart", "Rivière Noire", "Rodrigues", "Savanne", "Vacoas-Phoenix" };
                    break;
                case "Mexico":
                    states = new string[] { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", "Chiapas", "Chihuahua", "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "Mexico City", "Mexico State", "Michoacán", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo", "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas" };
                    break;
                case "Micronesia":
                    states = new string[] { "Chuuk", "Kosrae", "Pohnpei", "Yap" };
                    break;
                case "Moldova":
                    states = new string[] { "Anenii Noi", "Bălți", "Bender", "Briceni", "Cahul", "Călărași", "Cantemir", "Căușeni", "Cimișlia", "Criuleni", "Dondușeni", "Drochia", "Dubăsari", "Edineț", "Fălești", "Florești", "Glodeni", "Hîncești", "Ialoveni", "Leova", "Nisporeni", "Ocnița", "Orhei", "Rezina", "Rîșcani", "Sîngerei", "Soroca", "Șoldănești", "Strășeni", "Taraclia", "Telenești", "Ungheni" };
                    break;
                case "Monaco":
                    states = new string[] { "Fontvieille", "La Colle", "La Condamine", "Monte Carlo", "Monaco-Ville" };
                    break;
                case "Mongolia":
                    states = new string[] { "Arkhangai", "Bayan-Ölgii", "Bayankhongor", "Bulgan", "Darkhan-Uul", "Dornod", "Dornogovi", "Dundgovi", "Govi-Altai", "Govisümber", "Khentii", "Khovd", "Khövsgöl", "Ömnögovi", "Orkhon", "Övörkhangai", "Selenge", "Sükhbaatar", "Töv", "Uvs", "Zavkhan" };
                    break;
                case "Montenegro":
                    states = new string[] { "Andrijevica", "Bar", "Berane", "Bijelo Polje", "Budva", "Cetinje", "Danilovgrad", "Gusinje", "Herceg Novi", "Kolašin", "Kotor", "Mojkovac", "Nikšić", "Plav", "Pljevlja", "Plužine", "Podgorica", "Rožaje", "Šavnik", "Tivat", "Ulcinj", "Žabljak" };
                    break;
                case "Morocco":
                    states = new string[] { "Agadir-Ida-Ou-Tanane", "Al Hoceïma", "Azilal", "Beni Mellal", "Béni Mellal-Khénifra", "Berkane", "Boujdour", "Boulemane", "Casablanca", "Chefchaouen", "Chichaoua", "Dakhla", "Drâa-Tafilalet", "El Hajeb", "El Jadida", "Errachidia", "Essaouira", "Fahs Anjra", "Fès-Meknès", "Figuig", "Guelmim", "Guelmim-Oued Noun", "Ifrane", "Inezgane-Aït Melloul", "Jerada", "Kénitra", "Khemisset", "Khénifra", "Khouribga", "Laâyoune", "Laâyoune-Sakia El Hamra", "Larache", "Marrakesh-Safi", "Marrakech", "Médiouna", "Meknès", "Midelt", "Mohammadia", "Nador", "Nouaceur", "Ouarzazate", "Oued Ed-Dahab", "Oued Ed-Dahab-Lagouira", "Oujda-Angad", "Rabat", "Rabat-Salé-Kénitra", "Safi", "Sefrou", "Settat", "Sidi Kacem", "Sidi Slimane", "Souss-Massa", "Tanger-Tetouan-Al Hoceima", "Tangier", "Tan-Tan", "Taounate", "Taourirt", "Taroudant", "Tata", "Taza", "Tétouan", "Tiznit" };
                    break;
                case "Mozambique":
                    states = new string[] { "Cabo Delgado", "Gaza", "Inhambane", "Manica", "Maputo", "Nampula", "Niassa", "Sofala", "Tete", "Zambezia" };
                    break;
                case "Myanmar":
                    states = new string[] { "Ayeyarwady", "Bago", "Chin State", "Kachin State", "Kayah State", "Kayin State", "Magway", "Mandalay", "Mon State", "Naypyidaw", "Rakhine State", "Sagaing", "Shan State", "Tanintharyi", "Yangon" };
                    break;
                case "Namibia":
                    states = new string[] { "Erongo", "Hardap", "Karas", "Kavango East", "Kavango West", "Khomas", "Kunene", "Ohangwena", "Omaheke", "Omusati", "Oshana", "Oshikoto", "Otjozondjupa", "Zambezi" };
                    break;
                case "Nauru":
                    states = new string[] { "Aiwo", "Anabar", "Anetan", "Anibare", "Baiti", "Boe", "Buada", "Denigomodu", "Ewa", "Ijuw", "Meneng", "Nibok", "Uaboe", "Yaren" };
                    break;
                case "Nepal":
                    states = new string[] { "Bagmati", "Bheri", "Dhawalagiri", "Gandaki", "Janakpur", "Karnali", "Kosi", "Lumbini", "Mahakali", "Mechi", "Narayani", "Rapti", "Sagarmatha", "Seti" };
                    break;
                case "Netherlands":
                    states = new string[] { "Drenthe", "Flevoland", "Friesland", "Gelderland", "Groningen", "Limburg", "North Brabant", "North Holland", "Overijssel", "South Holland", "Utrecht", "Zeeland" };
                    break;
                case "New Zealand":
                    states = new string[] { "Auckland", "Bay of Plenty", "Canterbury", "Chatham Islands", "Gisborne", "Hawke's Bay", "Manawatu-Wanganui", "Marlborough", "Nelson", "Northland", "Otago", "Southland", "Taranaki", "Tasman", "Waikato", "Wellington", "West Coast" };
                    break;
                case "Nicaragua":
                    states = new string[] { "Boaco", "Carazo", "Chinandega", "Chontales", "Estelí", "Granada", "Jinotega", "León", "Madriz", "Managua", "Masaya", "Matagalpa", "Nueva Segovia", "Río San Juan", "Rivas", "North Caribbean Coast Autonomous Region", "South Caribbean Coast Autonomous Region" };
                    break;
                case "Niger":
                    states = new string[] { "Agadez", "Diffa", "Dosso", "Maradi", "Niamey", "Tahoua", "Tillabéri", "Zinder" };
                    break;
                case "Nigeria":
                    states = new string[] { "Abia", "Adamawa", "Akwa Ibom", "Anambra", "Bauchi", "Bayelsa", "Benue", "Borno", "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Enugu", "Federal Capital Territory", "Gombe", "Imo", "Jigawa", "Kaduna", "Kano", "Katsina", "Kebbi", "Kogi", "Kwara", "Lagos", "Nasarawa", "Niger", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers", "Sokoto", "Taraba", "Yobe", "Zamfara" };
                    break;
                case "North Korea":
                    states = new string[] { "Chagang", "Kangwon", "North Hamgyong", "North Hwanghae", "North Pyongan", "Pyongyang", "Ryanggang", "South Hamgyong", "South Hwanghae", "South Pyongan" };
                    break;
                case "North Macedonia":
                    states = new string[] { "Berovo", "Bitola", "Bogdanci", "Debar", "Delčevo", "Demir Hisar", "Demir Kapija", "Dojran", "Gevgelija", "Gostivar", "Gradsko", "Kavadarci", "Kičevo", "Kočani", "Kratovo", "Kriva Palanka", "Krivogaštani", "Kruševo", "Kumanovo", "Makedonska Kamenica", "Makedonski Brod", "Negotino", "Ohrid", "Pehčevo", "Prilep", "Probištip", "Radoviš", "Resen", "Shtip", "Struga", "Strumica", "Sveti Nikole", "Tearce", "Tetovo", "Valandovo", "Veles", "Vevčani", "Vinica", "Vraneštica", "Vrapčište", "Zelenikovo", "Zrnovci" };
                    break;
                case "Norway":
                    states = new string[] { "Agder", "Innlandet", "Møre og Romsdal", "Nordland", "Oslo", "Rogaland", "Troms og Finnmark", "Trøndelag", "Vestfold og Telemark", "Vestland", "Viken" };
                    break;
                case "Oman":
                    states = new string[] { "Ad Dakhiliyah", "Al Batinah North", "Al Batinah South", "Al Buraimi", "Al Wusta", "Ash Sharqiyah North", "Ash Sharqiyah South", "Dhofar", "Musandam", "Muscat" };
                    break;
                case "Pakistan":
                    states = new string[] { "Azad Jammu and Kashmir", "Balochistan", "Gilgit-Baltistan", "Islamabad Capital Territory", "Khyber Pakhtunkhwa", "Punjab", "Sindh" };
                    break;
                case "Palau":
                    states = new string[] { "Aimeliik", "Airai", "Angaur", "Hatohobei", "Kayangel", "Koror", "Melekeok", "Ngaraard", "Ngarchelong", "Ngardmau", "Ngatpang", "Ngchesar", "Ngeremlengui", "Ngiwal", "Peleliu", "Sonsorol" };
                    break;
                case "Panama":
                    states = new string[] { "Bocas del Toro", "Chiriquí", "Coclé", "Colón", "Darién", "Emberá", "Herrera", "Guna Yala", "Los Santos", "Ngäbe-Buglé", "Panamá", "Panamá Oeste", "Veraguas" };
                    break;
                case "Papua New Guinea":
                    states = new string[] { "Bougainville", "Central", "Chimbu", "East New Britain", "East Sepik", "Eastern Highlands", "Enga", "Gulf", "Hela", "Jiwaka", "Madang", "Manus", "Milne Bay", "Morobe", "National Capital District", "New Ireland", "Northern", "Southern Highlands", "West New Britain", "Western", "Western Highlands" };
                    break;
                case "Paraguay":
                    states = new string[] { "Alto Paraguay", "Alto Paraná", "Amambay", "Asunción", "Boquerón", "Caaguazú", "Caazapá", "Canindeyú", "Central", "Concepción", "Cordillera", "Guairá", "Itapúa", "Misiones", "Ñeembucú", "Paraguarí", "Presidente Hayes", "San Pedro" };
                    break;
                case "Peru":
                    states = new string[] { "Amazonas", "Áncash", "Apurímac", "Arequipa", "Ayacucho", "Cajamarca", "Callao", "Cusco", "Huancavelica", "Huánuco", "Ica", "Junín", "La Libertad", "Lambayeque", "Lima", "Lima Region", "Loreto", "Madre de Dios", "Moquegua", "Pasco", "Piura", "Puno", "San Martín", "Tacna", "Tumbes", "Ucayali" };
                    break;
                case "Philippines":
                    states = new string[] { "Abra", "Agusan del Norte", "Agusan del Sur", "Aklan", "Albay", "Antique", "Apayao", "Aurora", "Basilan", "Bataan", "Batanes", "Batangas", "Benguet", "Biliran", "Bohol", "Bukidnon", "Bulacan", "Cagayan", "Camarines Norte", "Camarines Sur", "Camiguin", "Capiz", "Catanduanes", "Cavite", "Cebu", "Cotabato", "Davao de Oro", "Davao del Norte", "Davao del Sur", "Davao Occidental", "Davao Oriental", "Dinagat Islands", "Eastern Samar", "Guimaras", "Ifugao", "Ilocos Norte", "Ilocos Sur", "Iloilo", "Isabela", "Kalinga", "La Union", "Laguna", "Lanao del Norte", "Lanao del Sur", "Leyte", "Maguindanao", "Marinduque", "Masbate", "Misamis Occidental", "Misamis Oriental", "Mountain Province", "Negros Occidental", "Negros Oriental", "Northern Samar", "Nueva Ecija", "Nueva Vizcaya", "Occidental Mindoro", "Oriental Mindoro", "Palawan", "Pampanga", "Pangasinan", "Quezon", "Quirino", "Rizal", "Romblon", "Samar", "Sarangani", "Siquijor", "Sorsogon", "South Cotabato", "Southern Leyte", "Sultan Kudarat", "Sulu", "Surigao del Norte", "Surigao del Sur", "Tarlac", "Tawi-Tawi", "Zambales", "Zamboanga del Norte", "Zamboanga del Sur", "Zamboanga Sibugay" };
                    break;
                case "Poland":
                    states = new string[] { "Greater Poland", "Kuyavian-Pomeranian", "Lesser Poland", "Lodz", "Lower Silesian", "Lublin", "Lubusz", "Masovian", "Opole", "Podlasie", "Pomeranian", "Silesian", "Subcarpathian", "Swietokrzyskie", "Warmian-Masurian", "West Pomeranian" };
                    break;
                case "Portugal":
                    states = new string[] { "Aveiro", "Azores", "Beja", "Braga", "Bragança", "Castelo Branco", "Coimbra", "Évora", "Faro", "Guarda", "Leiria", "Lisbon", "Madeira", "Portalegre", "Porto", "Santarém", "Setúbal", "Viana do Castelo", "Vila Real", "Viseu" };
                    break;
                case "Qatar":
                    states = new string[] { "Ad Dawhah", "Al Daayen", "Al Khor", "Al Wakrah", "Ar Rayyan", "Ash Shamal", "Umm Salal" };
                    break;
                case "Romania":
                    states = new string[] { "Alba", "Arad", "Argeș", "Bacău", "Bihor", "Bistrița-Năsăud", "Botoșani", "Brăila", "Brașov", "București", "Buzău", "Călărași", "Caraș-Severin", "Cluj", "Constanța", "Covasna", "Dâmbovița", "Dolj", "Galați", "Giurgiu", "Gorj", "Harghita", "Hunedoara", "Ialomița", "Iași", "Ilfov", "Maramureș", "Mehedinți", "Mureș", "Neamț", "Olt", "Prahova", "Sălaj", "Satu Mare", "Sibiu", "Suceava", "Teleorman", "Timiș", "Tulcea", "Vâlcea", "Vaslui", "Vrancea" };
                    break;
                case "Russia":
                    states = new string[] { "Altai Krai", "Altai Republic", "Amur Oblast", "Arkhangelsk Oblast", "Astrakhan Oblast", "Bashkortostan Republic", "Belgorod Oblast", "Bryansk Oblast", "Buryatia Republic", "Chechnya Republic", "Chelyabinsk Oblast", "Chukotka Autonomous Okrug", "Chuvashia Republic", "Dagestan Republic", "Ingushetia Republic", "Irkutsk Oblast", "Ivanovo Oblast", "Jewish Autonomous Oblast", "Kabardino-Balkar Republic", "Kaliningrad Oblast", "Kalmykia Republic", "Kaluga Oblast", "Kamchatka Krai", "Karachay-Cherkess Republic", "Karelia Republic", "Kemerovo Oblast", "Khabarovsk Krai", "Khakassia Republic", "Khanty-Mansi Autonomous Okrug", "Kirov Oblast", "Komi Republic", "Kostroma Oblast", "Krasnodar Krai", "Krasnoyarsk Krai", "Kurgan Oblast", "Kursk Oblast", "Leningrad Oblast", "Lipetsk Oblast", "Magadan Oblast", "Mari El Republic", "Mordovia Republic", "Moscow", "Moscow Oblast", "Murmansk Oblast", "Nenets Autonomous Okrug", "Nizhny Novgorod Oblast", "North Ossetia-Alania Republic", "Novgorod Oblast", "Novosibirsk Oblast", "Omsk Oblast", "Orenburg Oblast", "Oryol Oblast", "Penza Oblast", "Perm Krai", "Primorsky Krai", "Pskov Oblast", "Rostov Oblast", "Ryazan Oblast", "Sakha (Yakutia) Republic", "Sakhalin Oblast", "Samara Oblast", "Saratov Oblast", "Smolensk Oblast", "Stavropol Krai", "Sverdlovsk Oblast", "Tambov Oblast", "Tatarstan Republic", "Tomsk Oblast", "Tula Oblast", "Tuva Republic", "Tver Oblast", "Tyumen Oblast", "Udmurtia Republic", "Ulyanovsk Oblast", "Vladimir Oblast", "Volgograd Oblast", "Vologda Oblast", "Voronezh Oblast", "Yamalo-Nenets Autonomous Okrug", "Yaroslavl Oblast", "Zabaykalsky Krai" };
                    break;
                case "Rwanda":
                    states = new string[] { "Eastern", "Kigali City", "Northern", "Southern", "Western" };
                    break;
                case "Saint Lucia":
                    states = new string[] { "Anse la Raye", "Castries", "Choiseul", "Dennery", "Gros Islet", "Laborie", "Micoud", "Soufrière", "Vieux Fort" };
                    break;
                case "Saint Vincent and the Grenadines":
                    states = new string[] { "Charlotte", "Grenadines", "Saint Andrew", "Saint David", "Saint George", "Saint Patrick" };
                    break;
                case "Samoa":
                    states = new string[] { "A'ana", "Aiga-i-le-Tai", "Atua", "Fa'asaleleaga", "Gaga'emauga", "Gagaifomauga", "Palauli", "Satupa'itea", "Tuamasaga", "Va'a-o-Fonoti", "Vaisigano" };
                    break;
                case "San Marino":
                    states = new string[] { "San Marino" };
                    break;
                case "Sao Tome and Principe":
                    states = new string[] { "Principe", "Sao Tome" };
                    break;
                case "Saudi Arabia":
                    states = new string[] { "Al Bahah", "Al Jawf", "Al Madinah", "Al-Qassim", "Asir", "Eastern Province", "Hail", "Jizan", "Makkah", "Najran", "Northern Borders", "Riyadh", "Tabuk" };
                    break;
                case "Senegal":
                    states = new string[] { "Dakar", "Diourbel", "Fatick", "Kaffrine", "Kaolack", "Kedougou", "Kolda", "Louga", "Matam", "Saint-Louis", "Sedhiou", "Tambacounda", "Thies", "Ziguinchor" };
                    break;
                case "Serbia":
                    states = new string[] { "Belgrade", "Bor", "Branicevo", "Jablanica", "Kolubara", "Moravica", "Nisava", "Pcinja", "Pirot", "Podunavlje", "Pomoravlje", "Rasina", "Raska", "Sumadija", "Toplica", "Zajecar", "Zlatibor" };
                    break;
                case "Seychelles":
                    states = new string[] { "Anse aux Pins", "Anse Boileau", "Anse Etoile", "Anse Royale", "Anse-aux-Pins", "Au Cap", "Baie Lazare", "Baie Sainte Anne", "Beau Vallon", "Bel Air", "Bel Ombre", "Cascade", "Glacis", "Grand Anse Mahe", "Grand Anse Praslin", "La Digue", "La Riviere Anglaise", "Mont Buxton", "Mont Fleuri", "Plaisance", "Pointe La Rue", "Port Glaud", "Saint Louis", "Takamaka" };
                    break;
                case "Sierra Leone":
                    states = new string[] { "Eastern Province", "Northern Province", "Southern Province", "Western Area" };
                    break;
                case "Singapore":
                    states = new string[] { "Central Region", "East Region", "North Region", "North-East Region", "West Region" };
                    break;
                case "Slovakia":
                    states = new string[] { "Banská Bystrica", "Bratislava", "Košice", "Nitra", "Prešov", "Trenčín", "Trnava", "Žilina" };
                    break;
                case "Slovenia":
                    states = new string[] { "Ajdovščina", "Beltinci", "Bled", "Bohinj", "Borovnica", "Bovec", "Brda", "Brezovica", "Brežice", "Cankova", "Celje", "Cerklje na Gorenjskem", "Cerknica", "Cerkno", "Črenšovci", "Črna na Koroškem", "Črnomelj", "Destrnik", "Divača", "Dobrepolje", "Dobrova–Polhov Gradec", "Dol pri Ljubljani", "Domžale", "Dornava", "Dravograd", "Duplek", "Gorenja Vas–Poljane", "Gorišnica", "Gorje", "Gornja Radgona", "Gornji Grad", "Gornji Petrovci", "Grosuplje", "Hajdina", "Hoče–Slivnica", "Hodoš", "Horjul", "Hrastnik", "Hrpelje–Kozina", "Idrija", "Ig", "Ilirska Bistrica", "Ivančna Gorica", "Izola", "Jesenice", "Juršinci", "Kamnik", "Kanal", "Kidričevo", "Kobarid", "Kobilje", "Kočevje", "Komen", "Koper", "Kostanjevica na Krki", "Kostel", "Kozje", "Kranj", "Kranjska Gora", "Krško", "Kungota", "Kuzma", "Laško", "Lenart", "Lendava", "Litija", "Ljubljana", "Ljubno", "Ljutomer", "Log–Dragomer", "Logatec", "Loška Dolina", "Loški Potok", "Lovrenc na Pohorju", "Luče", "Lukovica", "Majšperk", "Maribor", "Medvode", "Mengeš", "Metlika", "Mežica", "Miklavž na Dravskem Polju", "Miren–Kostanjevica", "Mirna Peč", "Mislinja", "Mokronog–Trebelno", "Moravče", "Moravske Toplice", "Mozirje", "Murska Sobota", "Muta", "Naklo", "Nazarje", "Nova Gorica", "Novo Mesto", "Odranci", "Oplotnica", "Ormož", "Osilnica", "Pesnica", "Piran", "Pivka", "Podčetrtek", "Podlehnik", "Podvelka", "Polzela", "Postojna", "Prebold", "Preddvor", "Prevalje", "Ptuj", "Puconci", "Rače–Fram", "Radeče", "Radenci", "Radlje ob Dravi", "Radovljica", "Ravne na Koroškem", "Razkrižje", "Ribnica", "Rogaška Slatina", "Rogašovci", "Rogatec", "Ruše", "Semič", "Sevnica", "Sežana", "Slovenj Gradec", "Slovenska Bistrica", "Slovenske Konjice", "Sodražica", "Solčava", "Središče ob Dravi", "Starše", "Straža", "Sveta Ana", "Sveti Andraž v Slovenskih Goricah", "Sveti Jurij", "Sveti Jurij v Slovenskih Goricah", "Sveti Tomaž", "Tabor", "Tolmin", "Trbovlje", "Trebnje", "Trnovska Vas", "Tržič", "Turnišče", "Velenje", "Velika Polana", "Velike Lašče", "Veržej", "Videm", "Vipava", "Vitanje", "Vodice", "Vojnik", "Vransko", "Vrhnika", "Vuzenica", "Zagorje ob Savi", "Zavrč", "Zreče", "Žalec", "Železniki", "Žetale", "Žiri", "Benedikt", "Bistrica ob Sotli", "Bloke", "Braslovče", "Cankova", "Cerkvenjak", "Dobje", "Dobrna", "Dobrovnik", "Dolenjske Toplice", "Grad", "Hajdina", "Hoče–Slivnica", "Hodoš", "Horjul", "Jezersko", "Komenda", "Kostel", "Križevci", "Lovrenc na Pohorju", "Markovci", "Miklavž na Dravskem polju", "Mirna", "Oplotnica", "Podlehnik", "Polzela", "Prebold", "Prevalje", "Puconci", "Razkrižje", "Ribnica na Pohorju", "Selnica ob Dravi", "Sodražica", "Solčava", "Sveta Ana", "Sveti Andraž v Slovenskih goricah", "Šentrupert", "Šmarješke Toplice", "Tabor", "Trnovska vas", "Trzin", "Velika Polana", "Veržej", "Vitanje", "Vransko", "Žetale" };
                    break;
                case "Solomon Islands":
                    states = new string[] { "Central Province", "Choiseul Province", "Guadalcanal Province", "Honiara", "Isabel Province", "Makira-Ulawa Province", "Malaita Province", "Rennell and Bellona Province", "Temotu Province", "Western Province" };
                    break;
                case "Somalia":
                    states = new string[] { "Awdal", "Bakool", "Banaadir", "Bari", "Bay", "Galguduud", "Gedo", "Hiiraan", "Jubbada Dhexe", "Jubbada Hoose", "Mudug", "Nugaal", "Sanaag", "Shabeellaha Dhexe", "Shabeellaha Hoose", "Sool", "Togdheer", "Woqooyi Galbeed" };
                    break;
                case "South Africa":
                    states = new string[] { "Eastern Cape", "Free State", "Gauteng", "KwaZulu-Natal", "Limpopo", "Mpumalanga", "North West", "Northern Cape", "Western Cape" };
                    break;
                case "South Korea":
                    states = new string[] { "Seoul", "Busan", "Daegu", "Incheon", "Gwangju", "Daejeon", "Ulsan", "Sejong", "Gyeonggi", "Gangwon", "North Chungcheong", "South Chungcheong", "North Jeolla", "South Jeolla", "North Gyeongsang", "South Gyeongsang", "Jeju" };
                    break;
                case "South Sudan":
                    states = new string[] { "Central Equatoria", "Eastern Equatoria", "Jonglei", "Lakes", "Northern Bahr el Ghazal", "Unity", "Upper Nile", "Warrap", "Western Bahr el Ghazal", "Western Equatoria" };
                    break;
                case "Spain":
                    states = new string[] { "Andalusia", "Aragon", "Asturias", "Balearic Islands", "Basque Country", "Canary Islands", "Cantabria", "Castile and León", "Castile-La Mancha", "Catalonia", "Extremadura", "Galicia", "La Rioja", "Madrid", "Murcia", "Navarre", "Valencia" };
                    break;
                case "Sri Lanka":
                    states = new string[] { "Central Province", "Eastern Province", "Northern Province", "North Central Province", "North Western Province", "Sabaragamuwa Province", "Southern Province", "Uva Province", "Western Province" };
                    break;
                case "Sudan":
                    states = new string[] { "Red Sea", "River Nile", "North Darfur", "Khartoum", "White Nile", "Kassala", "North Kordofan", "Northern", "West Darfur", "South Darfur", "South Kordofan", "Blue Nile", "Sennar", "Gedaref", "West Kordofan", "East Darfur", "Central Darfur" };
                    break;
                case "Suriname":
                    states = new string[] { "Brokopondo", "Commewijne", "Coronie", "Marowijne", "Nickerie", "Para", "Paramaribo", "Saramacca", "Sipaliwini", "Wanica" };
                    break;
                case "Sweden":
                    states = new string[] { "Blekinge", "Dalarna", "Gotland", "Gävleborg", "Halland", "Jämtland", "Jönköping", "Kalmar", "Kronoberg", "Norrbotten", "Örebro", "Östergötland", "Skåne", "Södermanland", "Stockholm", "Uppsala", "Värmland", "Västerbotten", "Västernorrland", "Västmanland", "Västra Götaland" };
                    break;
                case "Switzerland":
                    states = new string[] { "Aargau", "Appenzell Ausserrhoden", "Appenzell Innerrhoden", "Basel-Landschaft", "Basel-Stadt", "Bern", "Fribourg", "Geneva", "Glarus", "Graubünden", "Jura", "Lucerne", "Neuchâtel", "Nidwalden", "Obwalden", "Schaffhausen", "Schwyz", "Solothurn", "St. Gallen", "Thurgau", "Ticino", "Uri", "Valais", "Vaud", "Zug", "Zurich" };
                    break;
                case "Syria":
                    states = new string[] { "Al-Hasakah", "Al-Raqqah", "Aleppo", "As-Suwayda", "Damascus", "Daraa", "Deir ez-Zor", "Hama", "Homs", "Idlib", "Latakia", "Quneitra", "Rif Dimashq", "Tartus" };
                    break;
                case "Taiwan":
                    states = new string[] { "Changhua County", "Chiayi City", "Chiayi County", "Hsinchu City", "Hsinchu County", "Hualien County", "Kaohsiung City", "Keelung City", "Kinmen County", "Lienchiang County", "Miaoli County", "Nantou County", "New Taipei City", "Penghu County", "Pingtung County", "Taichung City", "Tainan City", "Taipei City", "Taitung County", "Taoyuan City", "Yilan County", "Yunlin County" };
                    break;
                case "Tajikistan":
                    states = new string[] { "Sughd Region", "Khatlon Region", "GBAO", "Districts of Republican Subordination" };
                    break;
                case "Tanzania":
                    states = new string[] { "Arusha", "Dar es Salaam", "Dodoma", "Geita", "Iringa", "Kagera", "Katavi", "Kigoma", "Kilimanjaro", "Lindi", "Manyara", "Mara", "Mbeya", "Morogoro", "Mtwara", "Mwanza", "Njombe", "Pemba North", "Pemba South", "Pwani", "Rukwa", "Ruvuma", "Shinyanga", "Simiyu", "Singida", "Tabora", "Tanga", "Zanzibar Central/South", "Zanzibar North", "Zanzibar Urban/West" };
                    break;
                case "Thailand":
                    states = new string[] { "Bangkok", "Samut Prakan", "Nonthaburi", "Pathum Thani", "Phra Nakhon Si Ayutthaya", "Ang Thong", "Lop Buri", "Sing Buri", "Chai Nat", "Saraburi", "Nakhon Nayok", "Nakhon Pathom", "Samut Sakhon", "Ratchaburi", "Phetchaburi", "Prachuap Khiri Khan", "Chumphon", "Ranong", "Surat Thani", "Phang Nga", "Phuket", "Krabi", "Trang", "Satun", "Songkhla", "Pattani", "Yala", "Narathiwat", "Uttaradit", "Phitsanulok", "Phichit", "Kamphaeng Phet", "Sukhothai", "Uthai Thani", "Nakhon Sawan", "Nong Khai", "Loei", "Udon Thani", "Sakon Nakhon", "Nakhon Phanom", "Mukdahan", "Kalasin", "Sakon Nakhon", "Nakhon Ratchasima", "Buri Ram", "Surin", "Si Sa Ket", "Ubon Ratchathani", "Yasothon", "Chaiyaphum", "Amnat Charoen", "Nong Bua Lamphu", "Khon Kaen", "Udon Thani", "Loei", "Nong Khai", "Maha Sarakham", "Roi Et", "Kalasin", "Sakon Nakhon", "Nakhon Phanom", "Mukdahan", "Chiang Mai", "Lamphun", "Lampang", "Uttaradit", "Phrae", "Nan", "Phayao", "Chiang Rai", "Mae Hong Son", "Nakhon Sawan", "Uthai Thani", "Kamphaeng Phet", "Tak", "Sukhothai", "Phitsanulok", "Phichit", "Phetchabun", "Ratchaburi", "Kanchanaburi", "Suphan Buri", "Nakhon Pathom", "Samut Sakhon", "Samut Songkhram", "Phetchaburi", "Prachuap Khiri Khan", "Nakhon Si Thammarat", "Krabi", "Phang Nga", "Phuket", "Surat Thani", "Ranong", "Chumphon", "Songkhla", "Satun", "Trang", "Phatthalung", "Pattani", "Yala", "Narathiwat", "Krung Thep Maha Nakhon" };
                    break;
                case "Togo":
                    states = new string[] { "Centrale Region", "Kara Region", "Maritime Region", "Plateaux Region", "Savanes Region" };
                    break;
                case "Tonga":
                    states = new string[] { "Eua", "Ha'apai", "Niuas", "Tongatapu", "Vava'u" };
                    break;
                case "Trinidad and Tobago":
                    states = new string[] { "Arima", "Chaguanas", "Couva-Tabaquite-Talparo", "Diego Martin", "Eastern Tobago", "Penal-Debe", "Point Fortin", "Port of Spain", "Princes Town", "Rio Claro-Mayaro", "San Fernando", "San Juan-Laventille", "Sangre Grande", "Siparia", "Tunapuna-Piarco", "Western Tobago" };
                    break;
                case "Tunisia":
                    states = new string[] { "Ariana", "Beja", "Ben Arous", "Bizerte", "Gabes", "Gafsa", "Jendouba", "Kairouan", "Kasserine", "Kebili", "Kef", "Mahdia", "Manouba", "Medenine", "Monastir", "Nabeul", "Sfax", "Sidi Bouzid", "Siliana", "Sousse", "Tataouine", "Tozeur", "Tunis", "Zaghouan" };
                    break;
                case "Turkey":
                    states = new string[] { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Şanlıurfa", "Siirt", "Sinop", "Şırnak", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
                    break;
                case "Turkmenistan":
                    states = new string[] { "Ahal Region", "Balkan Region", "Daşoguz Region", "Lebap Region", "Mary Region" };
                    break;
                case "Uganda":
                    states = new string[] { "Central Region", "Eastern Region", "Northern Region", "Western Region" };
                    break;
                case "Ukraine":
                    states = new string[] { "Cherkasy Oblast", "Chernihiv Oblast", "Chernivtsi Oblast", "Dnipropetrovsk Oblast", "Donetsk Oblast", "Ivano-Frankivsk Oblast", "Kharkiv Oblast", "Kherson Oblast", "Khmelnytskyi Oblast", "Kiev", "Kirovohrad Oblast", "Luhansk Oblast", "Lviv Oblast", "Mykolaiv Oblast", "Odessa Oblast", "Poltava Oblast", "Rivne Oblast", "Sumy Oblast", "Ternopil Oblast", "Vinnytsia Oblast", "Volyn Oblast", "Zakarpattia Oblast", "Zaporizhzhia Oblast", "Zhytomyr Oblast" };
                    break;
                case "United Arab Emirates":
                    states = new string[] { "Abu Dhabi", "Ajman", "Dubai", "Fujairah", "Ras Al Khaimah", "Sharjah", "Umm Al Quwain" };
                    break;
                case "United Kingdom":
                    states = new string[] { "England", "Scotland", "Wales", "Northern Ireland" };
                    break;
                case "Uruguay":
                    states = new string[] { "Artigas", "Canelones", "Cerro Largo", "Colonia", "Durazno", "Flores", "Florida", "Lavalleja", "Maldonado", "Montevideo", "Paysandú", "Río Negro", "Rivera", "Rocha", "Salto", "San José", "Soriano", "Tacuarembó", "Treinta y Tres" };
                    break;
                case "Uzbekistan":
                    states = new string[] { "Andijan Region", "Bukhara Region", "Fergana Region", "Jizzakh Region", "Karakalpakstan", "Namangan Region", "Navoiy Region", "Qashqadaryo Region", "Samarqand Region", "Sirdaryo Region", "Surxondaryo Region", "Tashkent", "Tashkent Region", "Xorazm Region" };
                    break;
                case "Vanuatu":
                    states = new string[] { "Malampa", "Penama", "Sanma", "Shefa", "Tafea", "Torba" };
                    break;
                case "Vatican City":
                    states = new string[] { "Vatican City" };
                    break;
                case "Venezuela":
                    states = new string[] { "Amazonas", "Anzoátegui", "Apure", "Aragua", "Barinas", "Bolívar", "Carabobo", "Cojedes", "Delta Amacuro", "Falcón", "Federal Dependencies", "Guárico", "Lara", "Mérida", "Miranda", "Monagas", "Nueva Esparta", "Portuguesa", "Sucre", "Táchira", "Trujillo", "Vargas", "Yaracuy", "Zulia" };
                    break;
                case "Vietnam":
                    states = new string[] { "An Giang", "Bà Rịa–Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cao Bằng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Tĩnh", "Hải Dương", "Hậu Giang", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên–Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái", "Phú Yên", "Cần Thơ", "Đà Nẵng", "Hải Phòng", "Hà Nội", "Hồ Chí Minh" };
                    break;
                case "Yemen":
                    states = new string[] { "Abyan", "Ad Dali", "Aden", "Al Bayda", "Al Hudaydah", "Al Jawf", "Al Mahrah", "Al Mahwit", "Amran", "Dhamar", "Hadhramaut", "Hajjah", "Ibb", "Lahij", "Ma'rib", "Raymah", "Saada", "Sana'a", "Shabwah", "Socotra", "Ta'izz" };
                    break;
                case "Zambia":
                    states = new string[] { "Central Province", "Copperbelt Province", "Eastern Province", "Luapula Province", "Lusaka Province", "Muchinga Province", "Northern Province", "North-Western Province", "Southern Province", "Western Province" };
                    break;
                case "Zimbabwe":
                    states = new string[] { "Bulawayo", "Harare", "Manicaland", "Mashonaland Central", "Mashonaland East", "Mashonaland West", "Masvingo", "Matabeleland North", "Matabeleland South", "Midlands" };
                    break;
                default:
                    return [];
            };

            return states.ToList();
        }

        public List<string> GetStates(string countryName, string name)
        {
            var states = GetAllStatesByCountryName(countryName);

            return states.Where(x => x.Contains(name, StringComparison.InvariantCulture)).ToList();
        }
    }
}
