   M S B A M L   `   `   `  ����Z  VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF  5   	   N JInvoiceRegister.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InvoiceRegister.WPFInvoiceRegister.WPF 5   	   $   InvoiceRegister.WPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   HfaWPF6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	   3local!clr-namespace:InvoiceRegister.WPF     5   	   -   5          � Title$  Invoice Register��5	   	    � WindowState$ 	Maximized=�5
   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Common.xaml?�6%   �� 5      $' !../Styles/RoundedButtonStyle.xaml?�6%   %    5      .��5      �    BrushPrimaryBackground#��[  6    � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      $
��Auto �6   .+�5   
   ��   BrushSecondaryBackground#��[ 5       �� CornerRadius$ 10��5      $��10q�5       �� Padding$ 10q�5       $��Stretch=�5!      $��Stretch=�5"      ._�5#      � $��0��6    � ColumnDefinitions 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      .+�51      � $��0��6   .+�52      �� $	��Top=�6    $��Od��68   
�������$
��Bold"�6U   $��20,0,0,0q�6g   (  "System.Windows.Controls.DatePicker  53      $��25��6e   $
��auto��6q   $��Bottom=�6   
������ 	   SelectedDate	 6!   �� *FilterVM.FromDate+
 �� StringFormat$
 
MM/dd/yyyy��6�   �� 54      $	��Top=�6M   $
��Left=�6e    d� 	IsChecked 6   �� *FilterVM.FromDateToggle+6e   55      � 57      $��1��6   .+�58      �� $	��Top=�6    $��Do��68   
�������$
��Bold"�6U   $��20,0,0,0q�6g     59      $��25��6c   $
��auto��6o   $��Bottom=�6}   
������ 	 6!   �� *FilterVM.ToDate+$
 
MM/dd/yyyy��6�   �� 5:      $	��Top=�6K   $
��Left=�6c    6   �� *FilterVM.ToDateToggle+6c   5;      � 5=      $��2��6   .+�5>      �� $	��Top=�6    $��Minimalna cena��68   
�������$
��Bold"�6a   $��20,0,0,0q�6s   �� 5?      $��20��6A   $
��auto��6M   $��Bottom=�6[   
������ ��6   �� *FilterVM.MinPrice+6v   �� 5@      $	��Top=�6M   $
��Left=�6e    6   �� *FilterVM.MinPriceToggle+6e   5A      � 5C      $��3��6   .+�5D      �� $	��Top=�6    $��Maksymalna cena��68   
�������$
��Bold"�6b   $��20,0,0,0q�6t   �� 5E      $��20��6A   $
��auto��6M   $��Bottom=�6[   
������ ��6   �� *FilterVM.MaxPrice+6v   �� 5F      $	��Top=�6M   $
��Left=�6f    6   �� *FilterVM.MaxPriceToggle+6f   5G      � 5I      $��4��6   .+�5J      �� $	��Top=�6    $	��NIP��68   
�������$
��Bold"�6V   $��20,0,0,0q�6h   �� 5K      $��20��6B   $
��auto��6N   $��Bottom=�6\   
������ ��6   �� *FilterVM.ClientNIP+6w   �� 5L      $	��Top=�6N   $
��Left=�6g    6   �� *FilterVM.ClientNIPToggle+6g   5M      � 5O      $��5��6   .+�5P      �� $	��Top=�6    $��Nazwa firmy��68   
�������$
��Bold"�6^   $��20,0,0,0q�6p   �� 5Q      $��20��6C   $
��auto��6O   $��Bottom=�6]   
������ ��6   �� *FilterVM.ClientName+6x   �� 5R      $	��Top=�6O   $
��Left=�6i    6   �� *FilterVM.ClientNameToggle+6i   5S      � 5U      $��6��6   .+�5V      �� $	��Top=�6    $��Zalegające płatności��68   
�������$
��Bold"�6g   $��20,0,0,0q�6y   �� 5W      $	��Top=�6S   $
��Left=�6l    6   �� *FilterVM.OverduePaymentToggle+6l   5X      �� 5Z      -   5        $��7��5Z        RoundedButtonStyle#���  6)   $
��Bold"�6V   $��Filtruj wyniki��6h   $��Center=�6�   $��20��6�   $	��120��6�   6�   �� 5[      -   5        $��8��5[      #���  6)   $
��Bold"�6V   $��Stwórz fakturę��6h   $��Center=�6�   $��20��6�   $	��120��6�   6�   �� 5\      -   5        $��9��5\      #���  6)   $
��Bold"�6V   $��Wyślij ostrzeżenie��6h   $��Center=�6�   $��20��6�   $	��120��6�   6�   5]      5^      �� 5a   
   $��1��6   #��[ 5b      $ 10��5c      $��10q�5d      $ 10q�5e      $��Stretch=�5f      $��Stretch=�5g      ._�5h      � $��1��6   .+�5i      &   System.Windows.Controls.DataGrid  -   5          Name$ InvoicesGrid��5i   >      
IsReadOnly$
 True��6T   #��[ 6f   
������ ��6   �� *
InvoiceVMs+   Columns 5j      4  .System.Windows.Controls.DataGridTemplateColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$  ��61      CellTemplate 5l      �� 5m   "   .R�5n   &   �� -   5        ��5o   *   !   FontAwesome.WPF.FontAwesome  5p   .      Icon$ 
InfoCircle=�6@   
����iA�$
��Bold"�6j   
 � Tag 5r   *   �� 5s   .    �� Path$ Id�66   5u   '   5v   #   5x      0  *System.Windows.Controls.DataGridTextColumn  5y      $ Number faktury��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 10* 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *InvoiceNumber+6g     5z      $ Cena brutto��6-   $	 10* 6a    6B   �� *
PriceGross+6a     5{      $ Data wystawienia��6-   $	 10* 6�    6G   �� *	IssueDate+$
 {0:dd.MM.yyyy}��6�     5|      $ Data sprzedaży��6-   $	 10* 6�    6E   �� *
SaleDate+$
 {0:dd.MM.yyyy}��6�     5}      $ Termin płatności��6-   $	 10* 6�    6G   �� *PaymentDueDate+$
 {0:dd.MM.yyyy}��6�     5~      $ Status płatności��6-   $	 10* 6b    6G   �� *IsPaid+6b     5      $ Data płatności��6-   $	 10* 6�    6E   �� *PaymentDate+$
 {0:dd.MM.yyyy}��6�     5�      $ Nazwa��6-   $	 10* 6[    6<   �� *
ClientName+6[     5�      $	 NIP��6-   $	 10* 6X    6:   �� *	ClientNIP+6X   5�      5�      5�      5�      5�      