Here’s an explanation of the bindings in the CollectionView within your MainPage.xaml:
•	ItemsSource="{Binding People}"
This binds the CollectionView to the People property in your view model (MainPage.xaml.cs). People is an ObservableCollection<Person>, so any changes to this collection (add/remove/update) will automatically update the UI.
•	ItemTemplate / DataTemplate x:DataType="models:Person"
Each item in the CollectionView is expected to be of type Person. This enables compile-time binding checks and IntelliSense for the properties of Person.
Inside the Grid for each item:
•	<Label Text="{Binding FirstName}" />
Binds to the FirstName property of the current Person object.
•	<Label Text="{Binding LastName}" Grid.Column="1" />
Binds to the LastName property of the current Person object.
•	<Label Grid.Column="2"> ... <Span Text="{MultiBinding {Binding DoB}, StringFormat='{0:MM-dd-yyyy}'}"/> ... </Label>
Binds to the DoB (Date of Birth) property of the current Person object. The date is formatted as MM-dd-yyyy.
Note: The use of MultiBinding here is not standard in .NET MAUI XAML; typically, you would use {Binding DoB, StringFormat='{0:MM-dd-yyyy}'} directly.
Summary:
Each row in the CollectionView displays a person's first name, last name, and formatted date of birth, all bound to the corresponding properties of the Person model in your People collection. The bindings ensure the UI reflects the current state of your data.
