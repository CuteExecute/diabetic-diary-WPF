   M S B A M L   `   `   `  ����K  GSweetControl_2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SweetControl_2._0SweetControl_2._0  5   	   A%clr-namespace:SweetControl_2._0.ViewsSweetControl_2._0.Views  5   	   K*clr-namespace:SweetControl_2._0.ViewModelsSweetControl_2._0.ViewModels  5   	   "    SweetControl_2._0.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SweetControl_2._0     5   	   ;	localView%clr-namespace:SweetControl_2._0.Views     5   	   9vm*clr-namespace:SweetControl_2._0.ViewModels     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5
   	     � Title$  SweetControl_2.0��5   	   $	��450��6"   $	��800��6/    � WindowStyle$
 None=�6;    � 
ResizeMode$ NoResize=�6N    � DataContext 5      0  *SweetControl_2._0.ViewModels.MainViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 �� Triggers
 P� Property P� Value��%�  '��       �� 5   
   " ��6   .�5      ��  � �� �	#FFF77B9D6+   �� 5       � ��$ Comic Sans MS)�6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   
���   �$��0q�6_   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      	 5      P� 5       
 �@J�IsMouseOver . . �5"      ��  � �� �#8d6c9f63   5#      5%      5&      ��5'      �� 5(   
   .��5+      � -   5        $��MainGrid��5+      ��5-   
   �� 5.       �� Opacity$	 1.0Q�6    �� Color$ #FDAEC4��6,    � RowDefinitions 51   
   �� 52      $
��0.2* �6   6,   �� 53      $
��0.4* �6   6,   �� 54      $
��0.2* �6   6,   �� 55      6   �� 56      6    � ColumnDefinitions 58   
   �� 59      6!   �� 5:      6!   �� 5;      6!   .+�5>   
   � $��0��6   $��1��5?      $��3��5@      ���	#FFF77B9D5C      � 5E   
   $��0��6   $��2��5F      $��3��5G      $��3��5H      ���#FDAEC4.+�5K      �� "  WpfAnimatedGif.ImageBehavior   RepeatBehavior$ Forever��6      AnimationSpeedRatio$ 1X�5L         AnimatedSource$ Resources\sakura.gif��5M      $��UniformToFill=�5N       J� Opacity$	 0.5Q�5O      5Q      � 5S   
   $��0��6   $��3��5T      $��3��5U      $��2��5V      .+�5X      �� -   5        $��contentMain��5X      .��5Y      0   *SweetControl_2._0.Views.UserControlResults  5Z      5\      �� 5^   
   -   5        $��
MoveBorder��5^      $��0��5_      $��3��5`      $��0��5a      ���#FDAEC4._�5c      �� $	��350��6   $
��Left=�6$   ��5e      �� 5f      $	 0.0Q�6&   $ White��64   .@�5i      �� .��5j      �� -   5        $��Version��5j       $��v_alpha_1.0��5k      $��15(�5l      $
��auto��5m      ���	#FFF77B9D5o      5p      �� 5r      ���	#FFF77B9D6   �� 5t      .��5u      �� -   5        $��
MemoryText��5u       ���	#FFF77B9D$��15(�5x      $
��auto��5y      ��5v      �� *Memory+5{      5|      �� 5~      ���	#FFF77B9D6   �� 5�      .��5�      �� -   5        $��TestText��5�       ���	#FFF77B9D$��15(�5�      $
��auto��5�      ��5�      �� *Counter.Count+5�      5�      5�      5�      �� 5�   
   $��0��6   $��1��5�      $��3��5�       �� Orientation$ 
Horizontal=�5�      $
��Left=�5�      .+�5�      �� -   5        $��
ButtonGrid��5�      $��Таблица��5�      $��20(�5�      $	��150��5�      $
��Bold"�5�      $��0q�5�      ��5�      �� *
ClickAdd+5�      �� 5�      -   5        $��ButtonGraphic��5�      $��График��5�      $��20(�5�      $	��150��5�      $
��Bold"�5�      $��0q�5�      ��5�      �� *
ClickAdd+5�      5�      �� 5�   
   -	   5        $��
ButtonExit��5�      $	��100��5�      $	��100��5�      $��3��5�      $��0��5�      $��3��5�      ��5�      �� 5�      .R�5�      � .+�5�      A� $��8��6"   ���#8d6c9f
�������6G   �� 5�      $��	ExitImage��6    $��64��61   $��64��6=   $��Resources/ico1.png��6H    �� BitmapScalingMode$ HighQuality=�6d   5�       �� Triggers 5�      P� 5�      
 �@J�IsMouseOver . . �5�      ��  �� 
TargetName$ 	ExitImage��6%    � ��$ Resources/ico2.png��6N   5�      5�      5�      5�      5�      