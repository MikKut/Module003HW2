using Module003HW2.Validation;
using Module003HW2.Proxy;
using Module003HW2.Models.PhoneRecord;

try
{
    var englishPhoneRecorInstance = EnglishPhoneRecordValidator.GetInstance();
    var listEnglish = new PhoneListProxy(englishPhoneRecorInstance);
    var listUkrainian = new PhoneListProxy(UkrainianPhoneRecordValidator.GetInstance());
    IPhoneRecord phoneRecordE1 = new PhoneRecord("1", "+447975777666", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordE2 = new PhoneRecord("Ab", "+447975777665", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordE3 = new PhoneRecord("Ac", "+447975777664", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordE4 = new PhoneRecord("Ad", "+447975777663", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordE5 = new PhoneRecord("vd", "+447975777662", SupportedCultures.EnglishCultureInfo);

    IPhoneRecord phoneRecordU1 = new PhoneRecord("2", "+380992892697", SupportedCultures.UkrainianCultureInfo);
    IPhoneRecord phoneRecordU11 = new PhoneRecord("1", "+380592892697", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordU2 = new PhoneRecord("Ab", "+380692892697", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordU3 = new PhoneRecord("Ac", "+380612892697", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordU4 = new PhoneRecord("Ad", "+380692892691", SupportedCultures.EnglishCultureInfo);
    IPhoneRecord phoneRecordU5 = new PhoneRecord("vd", "+380692892698", SupportedCultures.EnglishCultureInfo);

    listUkrainian.Add(phoneRecordU1);
    listUkrainian.Add(phoneRecordU11);
    listUkrainian.Add(phoneRecordU2);
    listUkrainian.Add(phoneRecordU3);
    listUkrainian.Add(phoneRecordU4);
    listUkrainian.Add(phoneRecordU5);

    // listUkrainian.Add(new PhoneRecord("2", "+3280992892697", SupportedCultures.UkrainianCultureInfo);); - error because of the number
    foreach (var keyValuePairRec in listUkrainian.GetRecordsOfTheLanguage(UkrainianPhoneRecordValidator.GetInstance().GetCulture()))
    {
        Console.WriteLine(keyValuePairRec.Key.ToString() + ":\n");
        foreach (var valueKey in keyValuePairRec.Value)
        {
            Console.WriteLine(valueKey);
        }
    }

    Console.WriteLine();

    listEnglish.Add(phoneRecordE1);
    listEnglish.Add(phoneRecordE2);
    listEnglish.Add(phoneRecordE3);
    listEnglish.Add(phoneRecordE4);
    listEnglish.Add(phoneRecordE5);

    foreach (var keyValuePairRec in listEnglish.GetRecordsOfTheLanguage(EnglishPhoneRecordValidator.GetInstance().GetCulture()))
    {
        Console.WriteLine(keyValuePairRec.Key.ToString() + ":\n");
        foreach (var valueKey in keyValuePairRec.Value)
        {
            Console.WriteLine(valueKey);
        }
    }

    if (listEnglish.Delete(phoneRecordE5))
    {
        Console.WriteLine($"Can delete {phoneRecordE5.Name} from english list because it is in list");
    }

    Console.WriteLine("Renovated list:");
    foreach (var keyValuePairRec in listEnglish.GetRecordsOfTheLanguage(EnglishPhoneRecordValidator.GetInstance().GetCulture()))
    {
        Console.WriteLine(keyValuePairRec.Key.ToString() + ":\n");
        foreach (var valueKey in keyValuePairRec.Value)
        {
            Console.WriteLine(valueKey);
        }
    }

    var existingEl = listEnglish.GetRecordByNameOrReturnDefault(phoneRecordE4.Name);
    var nullElement = listEnglish.GetRecordByNameOrReturnDefault("23424");
    if (nullElement == null)
    {
        Console.WriteLine("NUll element is truly null");
    }

    if (existingEl != null)
    {
        Console.WriteLine(existingEl.Name);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}