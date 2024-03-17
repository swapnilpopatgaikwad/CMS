namespace CMS.Services
{
    public class LanguageService
    {
        public List<string> GetAllLanguages()
        {
            return ["Abkhazian", "Achinese", "Acoli", "Adangme", "Adyghe; Adygei", "Afar", "Afrihili", "Afrikaans", "Afro-Asiatic", "Akan", "Akkadian", "Albanian", "Albanian", "Aleut",
                "Algonquian", "Amharic", "Apache", "Arabic", "Aragonese", "Aramaic", "Arapaho", "Araucanian", "Arawak", "Armenian", "Armenian", "Assamese", "Asturian; Bable", "Athapascan",
                "Australian", "Austronesian", "Avaric", "Avestan", "Awadhi", "Aymara", "Azerbaijani", "Balinese", "Baluchi", "Bambara", "Bamileke", "Banda", "Bavarian", "Bantu", "Basa",
                "Bashkir", "Basque", "Basque", "Batak", "Beja", "Belarusian", "Bemba", "Bengali", "Berber", "Bhojpuri", "Bihari", "Bikol", "Bini", "Bislama", "Baruga", "Blin", "Norwegian",
                "Bosnian", "Braj", "Breton", "Buginese", "Bulgarian", "Buriat", "Burmese", "Burmese", "Caddo", "Carib", "Spanish", "Valencian", "Cebuano", "Celtic", "Central American Indian",
                "Chagatai", "Chamic", "Chamorro", "Chechen", "Cherokee", "Cheyenne", "Chibcha", "Nyanja; Chichewa; Chewa", "Chinese", "Chinese", "Chinook jargon", "Chipewyan", "Choctaw",
                "Zhuang; Chuang", "Chuukese", "Chuvash", "Old Newari; Classical Newari; Classical Nepal Bhasa", "Mandarin Chinese", "Coptic", "Cornish", "Corsican", "Cree", "Creek",
                "Creoles and pidgins", "Creoles and pidgins, English-based", "Creoles and pidgins, French-based", "Creoles and pidgins, Portuguese-based", "Crimean Tatar; Crimean Turkish",
                "Croatian", "Croatian", "Cushitic", "Czech", "Czech", "Dakota", "Danish", "Dargwa", "Dayak", "Delaware", "Dinka", "Divehi", "Dogri", "Dogrib", "Dravidian", "Duala", "Flemish; Dutch",
                "Flemish; Dutch", "Dutch", "Dyula", "Dzongkha", "Efik", "Egyptian", "Ekajuk", "Elamite", "US English", "English", "English", "Erzya", "Esperanto", "Estonian", "Ewe", "Ewondo",
                "Fang", "Fanti", "Faroese", "Fijian", "Pilipino; Filipino", "Finnish", "Finno-Ugrian", "Fon", "French", "French", "French", "French", "Frisian", "Friulian", "Fulah", "Ga",
                "Scottish Gaelic; Gaelic", "Gallegan", "Ganda", "Gayo", "Gbaya", "Geez", "Georgian", "Georgian", "German", "Deutsch", "Saxon, Low; German, Low; Low Saxon; Low German", "German",
                "German", "Germanic", "Kikuyu; Gikuyu", "Gilbertese", "Gondi", "Gorontalo", "Gothic", "Grebo", "Greek", "Greek", "Greek", "Kalaallisut; Greenlandic", "Guarani", "Gujarati", "Gwich’in",
                "Haida", "Haitian Creole; Haitian", "Hausa", "Hawaiian", "Hebrew", "Herero", "Hiligaynon", "Himachali", "Hindi", "Hiri Motu", "Hittite", "Hmong", "Hungarian", "Hupa", "Iban",
                "Icelandic", "Icelandic", "Ido", "Igbo", "Ijo", "Iloko", "Inari Sami", "Indic", "Indo-European", "Indonesian", "Ingush", "Interlingua", "Interlingue", "Inuktitut", "Inupiaq",
                "Iranian", "Irish", "Irish", "Irish", "Iroquoian", "Italian", "Japanese", "Javanese", "Judeo-Arabic", "Judeo-Persian", "Kabardian", "Kabyle", "Kachin", "Kalmyk", "Kamba", "Kannada",
                "Kanuri", "Karachay-Balkar", "Kara-Kalpak", "Karen", "Kashmiri", "Kashubian", "Kawi", "Kazakh", "Khasi", "Khmer", "Khoisan", "Khotanese", "Kimbundu", "Kinyarwanda", "Kirghiz",
                "Klingon", "Komi", "Kongo", "Konkani", "Korean", "Kosraean", "Kpelle", "Krio", "Kru", "Kumyk", "Kurdish", "Kurukh", "Kutenai", "Kwanyama, Kuanyama", "Ladino", "Lahnda", "Lamba",
                "Lao", "Latin", "Latvian", "Lezghian", "Limburgan; Limburger; Limburgish", "Lingala", "Lithuanian", "Lojban", "Lower Sorbian", "Lozi", "Luba-Katanga", "Luba-Lulua", "Luiseno",
                "Lule Sami", "Lunda", "Luo", "Lushai", "Luxembourgish; Letzeburgesch", "Macedonian", "Macedonian", "Madurese", "Magahi", "Maithili", "Makasar", "Malagasy", "Malay", "Malay",
                "Malayalam", "Maltese", "Manchu", "Mandar", "Mandingo", "Manipuri ", "Manobo", "Manx", "Maori", "Maori", "Marathi", "Mari", "Marshallese", "Marwari", "Masai", "Mayan", "Hassaniyya",
                "Mende", "Micmac; Mi'kmaq", "Minangkabau", "Mirandese", "Mohawk", "Moksha", "Moldavian", "Mon-Khmer", "Mongo", "Mongolian", "Mossi", "Multiple", "Munda", "Nahuatl", "Nauru",
                "Navajo; Navaho", "North Ndebele", "South Ndebele", "Ndonga", "Neapolitan", "Nepal Bhasa; Newari", "Nepali", "Nias", "Niger-Kordofanian", "Nilo-Saharan", "Niuean", "Nogai",
                "Norse", "North American Indian", "Northern Sami", "Sotho, Northern; Pedi; Sepedi", "Norwegian", "Nubian", "Nyamwezi", "Nyankole", "Nynorsk, Norwegian; Norwegian Nynorsk",
                "Nyoro", "Nzima", "Provençal; Occitan (post 1500) ", "Ojibwa", "Old Slavonic; Church Slavonic; Old Bulgarian; Church Slavic; Old Church Slavonic ", "Oriya", "Oromo", "Osage",
                "Ossetic; Ossetian", "Otomian", "Pahlavi", "Palauan", "Pali", "Pampanga", "Pangasinan", "Punjabi; Panjabi", "Papiamento", "Papuan", "Persian", "Persian", "Persian", "Phoenician",
                "Pohnpeian", "Polish", "Portuguese", "Prakrit", "Provençal", "Pushto", "Quechua", "Raeto-Romance", "Rajasthani", "Rapanui", "Rarotongan", "Romance", "Romanian", "Romanian", "Romany",
                "Rundi", "Russian", "Salishan", "Samaritan Aramaic", "Sami", "Samoan", "Sandawe", "Sango", "Sanskrit", "Santali", "Sardinian", "Sasak", "Scots", "Selkup", "Semitic", "Serbian", "Serbian",
                "Serer", "Shan", "Shona", "Sichuan Yi", "Sicilian", "Sidamo", "Sign", "Siksika", "Sindhi", "Sinhalese; Sinhala", "Sino-Tibetan", "Siouan", "Skolt Sami", "Slave", "Slavic", "Slovak",
                "Slovak", "Slovenian", "Sogdian", "Somali", "Songhai", "Soninke", "Sorbian", "Sotho, Southern", "South American Indian", "Southern Sami", "Sukuma", "Sumerian", "Sundanese", "Susu",
                "Swahili", "Swati", "Swedish", "Syriac", "Tagalog", "Tahitian", "Tai", "Tajik", "Tamashek", "Tamil", "Tatar", "Telugu", "Tereno", "Tetum", "Thai", "Tibetan", "Tibetan", "Tigre",
                "Tigrinya", "Timne", "Tiv", "Tlingit", "Tok Pisin", "Tokelau", "Tonga", "Tonga", "Tsimshian", "Tsonga", "Tswana", "Tumbuka", "Tupi", "Turkish", "Turkish", "Turkmen", "Tuvalu",
                "Tuvinian", "Twi", "Udmurt", "Ugaritic", "Uyghur; Uighur", "Ukrainian", "Umbundu", "Upper Sorbian", "Urdu", "Uzbek", "Vai", "Venda", "Vietnamese", "Volapük", "Votic", "Wakashan",
                "Walamo", "Walloon", "Waray", "Washo", "Welsh", "Welsh", "Wolof", "Xhosa", "Yakut", "Yao", "Yapese", "Yiddish", "Yoruba", "Yupik", "Zande", "Zapotec", "Zenaga", "Zulu", "Zuni"];
        }

        public List<string> GetAllLanguagesByName(string name)
        {
            var allLanguages = GetAllLanguages();

            return allLanguages.Where(x=> x.Contains(name, StringComparison.InvariantCulture)).ToList();
        }
    }
}
