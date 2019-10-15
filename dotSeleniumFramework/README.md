## Requirements :
1. dotnet 2.2
2. Nunit
3. Visual Studio 2017/2019
4. SpecFlow extension for Visual Studio

## TestSettings.json
You can switch `Browser` between "Firefox", "Chrome" and "Edge".
Edge has issues with Microsoft.Driver and needs to be repaired.

For Chrome you can set also `RunAsHeadless` to true (it will run headless).

## Validation of page loaded
Every page objects derives from `LoadablePage<T>` and has `EvaluateLoadedStatus()` method.
If it return `false` test will be stopped, and proper error message will be thrown.

## License:
MIT, and you can buy me a beer
