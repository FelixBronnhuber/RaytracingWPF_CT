   M S B A M L   `   `   `  ����K  GRaytracingWPF_CT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:RaytracingWPF_CT.ViewModelRaytracingWPF_CT.ViewModel  5   	   !    RaytracingWPF_CT.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7vm(clr-namespace:RaytracingWPF_CT.ViewModel     5   	     � Title$  RenderBaby v0.2��5   	   $	��500��6!   $	��800��6.    � DataContext 5	      .   (RaytracingWPF_CT.ViewModel.MainViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��100* �6   �� 5      $��10 �6   �� 5      $��25 �6   �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��100* �6   �� 5      $��10 �6   �� 5      $	��150 �6   �� 5      $��10 �6   �� 5      $	��150 �6   �� 5      $��10 �6   .+�5   
   �� $��1��6   $��1��6   $��3��6-    �� BitmapScalingMode$ NearestNeighbor=�6>   ��5      �� *BitmapSource+�� 5    
   $��1��6   $��3��6   $��3��6/    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$
 Auto=�5!      " �� VerticalScrollBarVisibility$
 Auto=�67   ��6Z   �� *TextBoxInput+�� 5"   
   $��3��6   $��3��6   $��Render Image��6.   ��6E   �� *RenderCommand+�� 5#   
   $��3��6   $��5��6   $��Save to PNG��6.   ��6D   �� *SafeImageCommand+5$      5%      