   M S B A M L   `   `   `  ����Z  VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF  5   	   N JInvoiceRegister.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InvoiceRegister.WPF.ViewsInvoiceRegister.WPF.Views 5   	   3   -InvoiceRegister.WPF.Views.CreateInvoiceWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   HfaWPF6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:InvoiceRegister.WPF.Views     5   	     � Title$  Create new invoice��5	   	   $	��300��6$   $	��500��61    � WindowStartupLocation$ CenterOwner=�5
   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Common.xaml?�6%   �� 5      $' !../Styles/RoundedButtonStyle.xaml?�6%   %    5      .��5      �    BrushPrimaryBackground#��[  6   .+�5   
   ��   BrushSecondaryBackground#��[ 5       �� CornerRadius$ 10��5      $��10q�5       �� Padding$ 10q�5      $��Stretch=�5      $��Stretch=�5      ._�5      �  � ColumnDefinitions 5      �� 5      $	��40* �6#   �� 5       $	��60* �6#    � RowDefinitions 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      .+�5+      �� $��0��6   $��0��6%   $��Numer faktury��65   $��Center=�6J   $��10,0,0,0q�6e   
�������$
��Bold"�6�   !   FontAwesome.WPF.FontAwesome  5,      -   5        	  Name$	 NumberWarning��5-   e   $��0��5,   !   $��0��6.   $y�Hidden=�6>   
   Icon$
 ExclamationCircle=�6R   
���  ��$��20��6|   $��20��6�   $��Center=�5-      $��Right=�67   $��0,10,0,0q�6S   6e   �� 5.      $��1��6   $��0��6%   $	��NIP��65   $��Center=�6@   $��10,0,0,0q�6[   
�������$
��Bold"�6�     5/      -   5        $	 
NIPWarning��50   e   $��1��5/       $��0��6-   $y�Hidden=�6=   $
 ExclamationCircle=�6Q   
���  ��$��20��6{   $��20��6�   $��Center=�50      $��Right=�67   $��0,10,0,0q�6S   6e   �� 51      $��2��6   $��0��6%   $��Data wystawienia��65   $��Center=�6M   $��10,0,0,0q�6h   
�������$
��Bold"�6�   �� 52      $��3��6   $��0��6%   $��Data sprzedaży��65   $��Center=�6K   $��10,0,0,0q�6f   
�������$
��Bold"�6�   �� 53      $��4��6   $��0��6%   $��Termin płatności��65   $��Center=�6M   $��10,0,0,0q�6h   
�������$
��Bold"�6�   �� 55      $��0��6F   $��1��6S   $��Center=�6c   $��0,0,10,0q�6~   
������ ��6   �� *CreateInvoiceVM.InvoiceNumber+6�   �� 56      $��1��6A   $��1��6N   $��Center=�6^   $��0,0,10,0q�6y   
������ ��6   �� *CreateInvoiceVM.ClientNIP+6�   (  "System.Windows.Controls.DatePicker  57      $��2��6e   $��1��6r   $��Center=�6�   $��	0,0,10, 0q�6�   
������    SelectedDate 6   �� *CreateInvoiceVM.IssueDate+ �� StringFormat$ 
MM/dd/yyyy��6�     58      $��3��6d   $��1��6q   $��Center=�6�   $��	0,0,10, 0q�6�   
������  6   �� *CreateInvoiceVM.SaleDate+$ 
MM/dd/yyyy��6�     59      $��4��6j   $��1��6w   $��Center=�6�   $��	0,0,10, 0q�6�   
������  6   �� * CreateInvoiceVM.PaymentDueDate+$ 
MM/dd/yyyy��6�   �� 5;      -   5         ��Name$ 	ErrorText��5;   Q   $��5��6   $��0��6%   $��2��65   $�� ��6I   
���  ��$��10,0,0,0q�6u   $
��Left=�6�   $��Center=�6�   �� 5<      -   5          RoundedButtonStyle#���  5<      $��5��6B   $��1��6O   $	��100��6_   $��20��6k   $��Right=�6w   $��0,0,10,0q�6�   $��Stwórz fakturę��6�   6�   5=      5>      5?      5@      