   M S B A M L   `   `   `  ����   
ProjektWPF    ProjektWPF.FilterWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Filtruj zadania��$	��350��$	��300�� � WindowStartupLocation$ CenterOwner=�.��� $��10q�.+��� .+��� $��
Kategoria:����  �� DisplayMemberPath$
 Name������ *
Categories+ �� SelectedItem �� *SelectedCategory+�� $��Pilnosc:��$��0,10,0,0q���  �� SelectedValue �� *SelectedPriority+.@��� $��(wszystkie)��
 � Tag Z� �� $��Niski��$ 0���� $��Sredni��$ 1���� $��Wysoki��$ 2���� $��Status:��$��0,10,0,0q���  �� *SelectedStatus+.@��� $��(wszystkie)�� Z� �� $��	Ukonczone��$
 true���� $��Nieukonczone��$ false���� $��Termin do dnia:��$��0,10,0,0q�(  "System.Windows.Controls.DatePicker     SelectedDate �� *	DueBefore+��  �� Orientation$ 
Horizontal=�$��Right=�$��0,15,0,0q�.+��� $��Zastosuj��$��80��$��5q� �� 	IsDefault$
 True������ *ApplyCommand+�� $��Anuluj��$��80��$��5q�	 �� IsCancel$
	 True��