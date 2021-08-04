# IniLib

![](https://img.shields.io/badge/status-deprecated-critical)


Library not longer being maintened, please go to ![Brokenegg.DotIni](https://github.com/brokenegg-io/Brokenegg.DotIni)

IniLib is a utility for creating and reading ".ini" files.  

## Usage

*Serializing*

```csharp
Product p = new Product();
p.name = "Potatoes";
p.price = 12;
IniFile ini = IniConverter.SerializeObject(p);
ini.Save(@"c:\test.ini");
```

*Deserializing*

```
Products[] ps = IniConverter.DeserializeObject<Product>(lines);
```
*Creating*

```
IniFile ini = new IniFile();
Section product = new Section("Product");
product.keys.add("name", product.name);
product.keys.add("price", product.price);
ini.sections.add(product);

ini.Save(@"c:\test.ini");
```

## System Requirements
* .Net Versions: 3.5+
* Operating Systems: Windows XP+.
