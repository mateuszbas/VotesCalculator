   M S B A M L   `   `   `  ���� J  FVotesCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VotesCalculator.PagesVotesCalculator.Pages  '    !VotesCalculator.Pages.SummaryPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:VotesCalculator.Pages       N� Title$  SummaryPage��.��� $��0,0,0,0q� � ColumnDefinitions �� $
��267* ��� $	��267 ��� $
��266* � � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� $��3��$��0��$��0��$
��10pxq�$��Center=�$��Center=�$��20(�These are the results!�� -    ��Name$ tbNullResults��$��2��$��2��$
��10pxq�$��Center=�$��Center=�$��20(��� -    ��Name$ 	btnExport��$��4��$��1��$
��10pxq�.��EXPORT�� -   $ btnMainPage��$��5��$��1��$
��10pxq�.��GO TO MAIN PAGE&   System.Windows.Controls.DataGrid  -     Name$ dgPartiesResults��$��3��$��Visible=�$��1��$��1��   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� 
 �� Path$	
 Key�  $ Votes��	 �� $
 Value�  -   $ dgCandidatesResults��$��3��$��Visible=�$��1�� .     $ Party��	 �� $	
 Key�  $ Votes��	 �� $
 Value��� -   $ btnShowCharts��$��4��$��2��$
��10pxq�$��SHOW CHARTS��