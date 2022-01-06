# VariableToFile
Saves variables and structs to binary files.
Can also load them.

<h1>Usage</h1>

```
string save_this = "some string";

VarSave.Saver save = new VarSave.Saver(@"Your path where you want your file saved here");
int return_value = save.SaveToFile<string>(save_this);
// string variable saved

//To retrieve it from file use:
VarSave.Loader load = new VarSave.Loader(@"Your path to saved file here");
int return_value1 = load.LoadFromFile(); // variable loaded to memory
string value = load.GetVar<string>(); // gets the value from memory

//now value from file is saved into "value" variable

```

More examples in `Examples.cs`
