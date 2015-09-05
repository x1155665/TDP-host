# TDP-host
a host program with UI on PC for a powder 3D-printer (inkjet)

Inspired by Plan B(http://ytec3d.com/plan-b/), our project team from CDHAW, tongji University developed a 3D printer based on Inkjet printing. The main difference between Plan B and our 3d-printer is that the PCB-board and the printing section of a comercial inkjet printer are uesd to conduct the print of each slice, which makes color printing even more available. An arduino board equiped with RAMPS1.4 controls the movements of the step motors and monitors the temperature of powder.
This program invokes freesteel slicer(http://www.freesteel.co.uk/wpblog/slicer/) to slice the STL model and then coordinate the motherboard, dissembled from an inkjet printer, and arduino to print the model out. 

The firmware for the arduino board:
