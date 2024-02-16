using System.Globalization;
using Microsoft.Extensions.Localization;

namespace i18nCustomLocalizer;

public class CustomStringLocalizer : IStringLocalizer
{
    private readonly CultureInfo _culture;

    private readonly List<CustomStringData> _stringData; 
               
    public CustomStringLocalizer()
    {
        _stringData = new List<CustomStringData>();
            
        InitializeLocalizedStrings(_stringData);
    }
        
    public CustomStringLocalizer(CultureInfo culture) : this()
    {
        _culture = culture;
    }
        
    public LocalizedString this[string name]
    {
        get
        {
            var culture = _culture ?? CultureInfo.CurrentUICulture;
            var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;
                
            return new LocalizedString(name, translation ?? name, translation != null);
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var culture = _culture ?? CultureInfo.CurrentUICulture;
            var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;

            if (translation != null)
            {
                translation = string.Format(translation, arguments);
            }
                
            return new LocalizedString(name, translation ?? name, translation != null);
        }
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        return _stringData.Select(x => new LocalizedString(x.Name, x.Value, true)).ToList();
    }
        
    public IStringLocalizer WithCulture(CultureInfo culture)
    {
        return new CustomStringLocalizer(culture);
    }
        
    private void InitializeLocalizedStrings(List<CustomStringData> localizedStrings)
    {
        localizedStrings.Clear();

        localizedStrings.Add(new CustomStringData("en-US", "Hello", "Hello"));
        localizedStrings.Add(new CustomStringData("en-US", "Goodbye", "Goodbye"));
        localizedStrings.Add(new CustomStringData("en-US", "CurrentDate", "Current Date"));
        localizedStrings.Add(new CustomStringData("en-US", "FormattedNumber", "Formatted Number"));
        localizedStrings.Add(new CustomStringData("en-US", "CurrencyValue", "Currency Value"));
        localizedStrings.Add(new CustomStringData("en-US", "DetectedCulture", "Detected Culture"));
        localizedStrings.Add(new CustomStringData("en-US", "DetectedUICulture", "Detected UI Culture"));

        localizedStrings.Add(new CustomStringData("it-IT", "Hello", "Ciao"));
        localizedStrings.Add(new CustomStringData("it-IT", "Goodbye", "Arrivederci"));
        localizedStrings.Add(new CustomStringData("it-IT", "CurrentDate", "Data Corrente"));
        localizedStrings.Add(new CustomStringData("it-IT", "FormattedNumber", "Numero Formattato"));
        localizedStrings.Add(new CustomStringData("it-IT", "CurrencyValue", "Valore di Valuta"));
        localizedStrings.Add(new CustomStringData("it-IT", "DetectedCulture", "Cultura rivelata"));
        localizedStrings.Add(new CustomStringData("it-IT", "DetectedUICulture", "Cultura UI rivelata"));

        localizedStrings.Add(new CustomStringData("ja-JP", "Hello", "こんにちは"));
        localizedStrings.Add(new CustomStringData("ja-JP", "Goodbye", "さようなら"));
        localizedStrings.Add(new CustomStringData("ja-JP", "CurrentDate", "現在の日付"));
        localizedStrings.Add(new CustomStringData("ja-JP", "FormattedNumber", "フォーマットされた数値"));
        localizedStrings.Add(new CustomStringData("ja-JP", "CurrencyValue", "通貨の値"));
        localizedStrings.Add(new CustomStringData("ja-JP", "DetectedCulture", "検出された文化"));
        localizedStrings.Add(new CustomStringData("ja-JP", "DetectedUICulture", "検出されたUI文化"));

        localizedStrings.Add(new CustomStringData("nl-NL", "Hello", "Hallo"));
        localizedStrings.Add(new CustomStringData("nl-NL", "Goodbye", "Tot ziens"));
        localizedStrings.Add(new CustomStringData("nl-NL", "CurrentDate", "Huidige Datum"));
        localizedStrings.Add(new CustomStringData("nl-NL", "FormattedNumber", "Opgemaakte Nummer"));
        localizedStrings.Add(new CustomStringData("nl-NL", "CurrencyValue", "Valutawaarde"));
        localizedStrings.Add(new CustomStringData("nl-NL", "DetectedCulture", "Ontdekte Cultuur"));
        localizedStrings.Add(new CustomStringData("nl-NL", "DetectedUICulture", "Ontdekte UI-cultuur"));

        localizedStrings.Add(new CustomStringData("ru-RU", "Hello", "Привет"));
        localizedStrings.Add(new CustomStringData("ru-RU", "Goodbye", "До свидания"));
        localizedStrings.Add(new CustomStringData("ru-RU", "CurrentDate", "Текущая дата"));
        localizedStrings.Add(new CustomStringData("ru-RU", "FormattedNumber", "Отформатированный номер"));
        localizedStrings.Add(new CustomStringData("ru-RU", "CurrencyValue", "Значение валюты"));
        localizedStrings.Add(new CustomStringData("ru-RU", "DetectedCulture", "Обнаруженная культура"));
        localizedStrings.Add(new CustomStringData("ru-RU", "DetectedUICulture", "Обнаружен UI Культура"));
    }
        
    private class CustomStringData
    {
        public CustomStringData(string cultureName, string name, string value)
        {
            CultureName = cultureName;
            Name = name;
            Value = value;
        }
        
        public string CultureName { get; private set; }
            
        public string Name {get; private set; }

        public string Value {get; private set; }
    }
}