Public Class frmHelp


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str1 As String = "This program can be used to convert the RF Dicom image Files to DX Dicom files which can be used in TiGRT TPS"
        Dim str2 As String = "The Tag 'Modality' identifies the file is a RF or DX file"

        Dim str3 As String = "On openeing a DICOM file, the program first identifies whether its a RF file and looks for other tags like"
        Dim str4 As String = "1. Image Plane Pixel Spacing "
        Dim str5 As String = "2. RTImage Position Plane"
        Dim str6 As String = "3. SAD"
        Dim str7 As String = "4. SID"
        Dim str8 As String = "If these DICOM tags are not present, then its assumed that the file is a RF image file"

        Dim str9 As String = "Press the 'AP Settings' button to get the optimized AP image settings. Its assumed that the magnification here is 1.33"
        Dim str10 As String = "Press the 'LR Settings' button to get the optimized LR image settings. Its assumed that the magnification here is 1.67"
        Dim str11 As String = "If the maginfications are different or the SAD/SID distances are different, manually you can enter the values in the textboxes."


        Dim str12 As String = "Once the settings are done, Press the Convert button."
        Dim str13 As String = "Settings are applied and file can be saved with any name."
        Dim str14 As String = "AP or LR is automatically added as per the Settings button pressed. Check the Status bar for update success or failure. "

        Label2.Text = str1 + vbCrLf + str2
        Label4.Text = str3 + vbCrLf + str4 + vbCrLf + str5 + vbCrLf + str6 + vbCrLf + str7 + vbCrLf + str8
        Label6.Text = str9 + vbCrLf + str10 + vbCrLf + str11
        Label7.Text = str12 + vbCrLf + str13 + vbCrLf + str14


    End Sub
End Class