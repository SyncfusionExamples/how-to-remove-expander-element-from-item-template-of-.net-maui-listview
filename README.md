# how-to-remove-expander-element-from-item-template-of-.net-maui-listview
The demo explains about how to remove or delete the .NET MAUI Expander (SfExpander) item from DisplayItems collection in .NET MAUI ListView(SfListView)

You can load the SfExpander in the ItemTemplate of SfListView and remove the expander at run time by updating the ListView collection in .NET MAUI

C#
The Commands defined in the ViewModel are used to customize the SfExpander and delete the same using the Remove method.

    public class ViewModelClass
     {
      #region Fields

      private ObservableCollection<InboxInfo> inboxInfo;

      #endregion

      #region Constructor

      public ViewModelClass()
      {
          ReadCommand = new Command<object>(OnReadClicked);
          DeleteCommand = new Command<object>(OnDeleteClicked);
          GenerateSource();
      }

      #endregion

      #region Properties

      public ObservableCollection<InboxInfo> InboxInfo
      {
          get { return inboxInfo; }
          set { this.inboxInfo = value; }
      }

      public Command<object> ReadCommand { get; set; }
      public Command<object> DeleteCommand { get; set; }
      #endregion

      #region Methods

      private void GenerateSource()
      {
          InboxInfoRepository inboxinfo = new InboxInfoRepository();
          inboxInfo = inboxinfo.GetInboxInfo();
      }


      private void OnDeleteClicked(object obj)
      {
          var expanderItem = obj as InboxInfo;
          this.InboxInfo.Remove(expanderItem);
      }

      private void OnReadClicked(object obj)
      {
          var expanderItem = obj as InboxInfo;
          expanderItem.FontStyle = FontAttributes.None;
          expanderItem.IsExpanded = false;
      }
      #endregion
    }
XAML

Loaded the SfExpander to the SfListView.ItemTemplate. ViewModel commands bound to the Button.Command and set BindingContext as the CommandParameter.

    <sflistView:SfListView x:Name="listView" ItemsSource="{Binding InboxInfo}" ItemSpacing="1">
    <sflistView:SfListView.ItemTemplate>
        <DataTemplate>
            <expander:SfExpander HeaderIconPosition="Start" IsExpanded="True">
                <expander:SfExpander.Header >
                    <Grid Padding="10,0,0,0" HeightRequest="70">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="100"/>
                        </Grid.ColumnDefinitions>
                        <Grid HorizontalOptions="StartAndExpand">
                            <Label LineBreakMode="NoWrap" FontSize="18" Text="{Binding Title}" VerticalOptions="Center"/>
                            <Label LineBreakMode="NoWrap" Grid.Row="1" Text="{Binding Subject}" FontSize="16" VerticalOptions="Center"/>
                        </Grid>
                        <Label HorizontalOptions="EndAndExpand" Padding="5,10,5,10" Grid.Column="1" LineBreakMode="NoWrap" Text="{Binding Date}" FontSize="12"/>
                    </Grid>
                </expander:SfExpander.Header>
                <expander:SfExpander.Content>
                    <Grid HeightRequest="100" >
                        <Grid.RowDefinitions>
                            <RowDefinition Height="0.6*"/>
                            <RowDefinition Height="0.4*"/>
                        </Grid.RowDefinitions>
                        <Label Text="{Binding Description}" VerticalOptions="Center"/>
                        <Grid Grid.Row="1">
                            <Button x:Name="save" Text="Mark as read" Command="{Binding Path=BindingContext.ReadCommand, Source={x:Reference listView}}" CommandParameter="{Binding .}" FontSize="15" BackgroundColor="#28abb9" CornerRadius="5" TextColor="White"/>
                            <Button x:Name="delete" Text="Delete" Command="{Binding Path=BindingContext.DeleteCommand, Source={x:Reference listView}}" CommandParameter="{Binding .}" Grid.Column="1" FontSize="15" BackgroundColor="#ea2c62" CornerRadius="5" TextColor="White"/>
                        </Grid>
                    </Grid>
                </expander:SfExpander.Content>
            </expander:SfExpander>
        </DataTemplate>
    </sflistView:SfListView.ItemTemplate>
    </sflistView:SfListView>