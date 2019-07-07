# TDP-host
A host program with UI on PC for a powder 3D-printer (inkjet)

Inspired by Plan B (http://ytec3d.com/plan-b/), our project team from CDHAW, Tongji University developed a 3D printer based on Inkjet printing. The main difference between Plan B and our 3d-printer is that the PCB-board and the printing section of a comercial inkjet printer are uesd to conduct the printing of each slice, which makes color printing possible. An arduino board equiped with RAMPS1.4 controls the movements of the step motors and monitors the temperature of powder.

This program invokes freesteel slicer(http://www.freesteel.co.uk/wpblog/slicer/) to slice the STL model and then coordinates the motherboard, which is dissembled from an inkjet printer, and arduino to print the model. 

The firmware for the arduino board: https://github.com/x1155665/TDP-arduino_firmware 
