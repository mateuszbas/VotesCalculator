   M S B A M L   `   `   `  ����J  FVotesCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VotesCalculator.PagesVotesCalculator.Pages  5      '    !VotesCalculator.Pages.SummaryPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:VotesCalculator.Pages     5        N� Title$  SummaryPage��5	      .��5      � $��0,0,0,0q�6    � ColumnDefinitions 5   
   �� 5      $
��267* �6   �� 5      $	��267 �6   �� 5      $
��266* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��3��6   $��0��6(   $��0��65   $
��10pxq�6E   $��Center=�6S   $��Center=�6p   $��20(�6�   These are the results!6�   �� 5   
   -   5         ��Name$ tbNullResults��5      $��2��6,   $��2��69   $
��10pxq�6I   $��Center=�6W   $��Center=�6t   $��20(�6�   �� 5   
   -   5         ��Name$ 	btnExport��5      $��4��6$   $��1��61   $
��10pxq�6A   .��6g   EXPORT6o   �� 5   
   -   5        $ btnMainPage��5      $��5��6&   $��1��63   $
��10pxq�6C   .��6l   GO TO MAIN PAGE6}   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgPartiesResults��5   $   $��3��6   $��Visible=�6>   $��1��6q   $��1��6~      AutoGenerateColumns .     Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� 
 �� Path$	
 Key�  5"      $ Votes��6%   	 64   �� $
 Value�5$        5%   
   -   5        $ dgCandidatesResults��5%   $   $��3��6   $��Visible=�6A   $��1��6t    .   5&        5'      $ Party��6%   	 64   �� $	
 Key�  5(      $ Votes��6%   	 64   �� $
 Value�5*      �� 5,   
   -   5        $ btnShowCharts��5,      $��4��6(   $��2��65   $
��10pxq�6E   $��SHOW CHARTS��6T   6j   5.      5/      