# RF2DX
Convert Diagnostic DICOM images to RT DICOM Image

C-Arm images used in Radiotherapy doesnt contain some important tags required for planning. These are 

30020011 - Pixel size
30020026 - SID distance
30020022 - SAD distance
30020012 - Image plane

Without these data, measuring of length becomes impossible and this program can add these informaton to the existing C-arm images. Meant for Branthytherapy planning but can be used when there is such requirements in other instances too.

Uses component from EvilDICOM. https://github.com/rexcardan/Evil-DICOM
https://github.com/rexcardan/Evil-DICOM
