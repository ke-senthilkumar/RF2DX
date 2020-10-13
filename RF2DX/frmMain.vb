Imports EvilDICOM
Imports EvilDICOM.Core
Imports EvilDICOM.Core.Element
Imports EvilDICOM.Core.IO
Imports EvilDICOM.Core.Modules

Public Class frmMain


    'Dim dcm = DICOMObject.Read("D:\DcmEditor\AP0252.dcm")
    Dim dcm As New DICOMObject
    Dim oFileName As String
    '  Dim strPatientName As Object

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub FindSID()

        Dim strSID As Object

        If dcm.FindFirst("30020026") Is Nothing Then
            strSID = "SID Data Not Found"
            Label5.Text = strSID
        Else
            strSID = dcm.FindFirst("30020026")
            Label5.Text = strSID.ToString
        End If
    End Sub

    Private Sub FindSAD()
        Dim strSAD As Object

        If dcm.FindFirst("30020022") Is Nothing Then
            strSAD = "SAD Data Not Found"
            Label4.Text = strSAD
        Else
            strSAD = dcm.FindFirst("30020022")
            Label4.Text = strSAD.ToString
        End If
    End Sub

    Private Sub FindPlane()
        Dim strPlane As Object

        If dcm.FindFirst("30020012") Is Nothing Then
            strPlane = "Pixel Plane Not Found"
            Label3.Text = strPlane
        Else
            strPlane = dcm.FindFirst("30020012")
            Label3.Text = strPlane.ToString
        End If
    End Sub

    Private Sub FindPixel()

        Dim strPixel As Object

        If dcm.FindFirst("30020011") Is Nothing Then
            strPixel = "Pixel Data Not Found"
            Label1.Text = strPixel
        Else
            strPixel = dcm.FindFirst("30020011")
            Label1.Text = strPixel.ToString
        End If
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        OpenDCMFile()
    End Sub

    Private Sub OpenDCMFile()
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            dcm = DICOMObject.Read(OpenFileDialog1.FileName)
        End If

        Dim strModality = dcm.FindFirst("00080060")
        Dim strPatientName = dcm.FindFirst("00100010")
        Dim strPatientID = dcm.FindFirst("00100020")

        FindPixel()
        FindPlane()
        FindSAD()
        FindSID()


        Label2.Text = strModality.ToString + vbCrLf + strPatientName.ToString + vbCrLf + strPatientID.ToString '+ vbCrLf + strpixel

        txtResults.Text = "Open Successful! Please Verify data"
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ModifySettings()
    End Sub

    Private Sub ModifySettings()
        ModifyModality()
        AddPixel()
        AddPlane()
        AddSAD()
        AddSID()

        ''  dcm.Write("d:\dcmeditor\new.dcm")
        SaveFileDialog1.Filter = "DICOM Files (*.dcm*)|*.dcm"
        SaveFileDialog1.FileName = oFileName

        Try
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                dcm.Write(SaveFileDialog1.FileName)

            End If
            txtResults.Text = "Save Successful"
        Catch ex As Exception
            txtResults.Text = "Save Failed! Sorry!"
        End Try
    End Sub

    Private Sub AddPixel()
        Dim ps = New DecimalString(New Tag("30020011"), 0.2)
        dcm.Add(ps)

        Dim sel = dcm.GetSelector()

        Dim dbls As New List(Of Double)

        dbls.Add(txtPix1.Text)
        dbls.Add(txtPix2.Text)
        sel.ImagePlanePixelSpacing.Data_ = dbls

    End Sub

    Private Sub AddPlane()
        Dim pp = New DecimalString(New Tag("30020012"), 0.2)
        dcm.Add(pp)
        Dim sel1 = dcm.GetSelector()

        Dim dbls1 As New List(Of Double)

        dbls1.Add(txtPlane1.Text)
        dbls1.Add(txtPlane2.Text)
        sel1.RTImagePosition.Data_ = dbls1


    End Sub

    Private Sub AddSAD()
        Dim sad = New DecimalString(New Tag("30020022"), 0.2)
        dcm.Add(sad)
        Dim sel2 = dcm.GetSelector()

        sel2.RadiationMachineSAD.Data = txtSAD.Text

    End Sub

    Private Sub AddSID()
        Dim sid = New DecimalString(New Tag("30020026"), 0.2)
        dcm.Add(sid)
        Dim sel3 = dcm.GetSelector()

        sel3.RTImageSID.Data = txtSID.Text

    End Sub

    Private Sub ModifyModality()

        Dim sel4 = dcm.GetSelector()
        sel4.Modality.Data = "DX"


    End Sub
    Private Sub APSet()
        txtPix1.Text = "0.252"
        txtPix2.Text = "0.252"
        txtPlane1.Text = "0"
        txtPlane2.Text = "0"
        txtSAD.Text = "1000"
        txtSID.Text = "1750"
        oFileName = "_AP"

        txtResults.Text = "AP Settings Applied. Please Verify them"
    End Sub
    Private Sub btnAPSet_Click(sender As Object, e As EventArgs) Handles btnAPSet.Click
        APSet()
    End Sub

    Private Sub LRSet()
        txtPix1.Text = "0.186"
        txtPix2.Text = "0.186"
        txtPlane1.Text = "0"
        txtPlane2.Text = "0"
        txtSAD.Text = "1000"
        txtSID.Text = "1600"
        oFileName = "_LR"

        txtResults.Text = "LR Settings Applied. Please Verify them"
    End Sub


    Private Sub btnLRSet_Click(sender As Object, e As EventArgs) Handles btnLRSet.Click
        LRSet()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenDCMFile()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ModifySettings()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Program to Modify Dicom RF to DX. Use for TiGRT TPS only!" + vbCrLf + "EvilDICOM component used. Thanks. http://rexcardan.github.io/Evil-DICOM/" + vbCrLf + "Program by KES", "Dicom Converter", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub TopicsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopicsToolStripMenuItem.Click
        Dim frm As New frmHelp
        frm.ShowDialog()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ApplyAPSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyAPSettingsToolStripMenuItem.Click
        APSet()
    End Sub

    Private Sub ApplyLRSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyLRSettingsToolStripMenuItem.Click
        LRSet()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            dcm = DICOMObject.Read(OpenFileDialog1.FileName)


        End If
    End Sub
End Class
