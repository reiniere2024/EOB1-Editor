Public Class Start1

    Private Sub Start_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CreateControls()

    End Sub

    Public Sub CreateControls()
        Dim l As Point

        For i As Integer = 0 To 15
            l.X = 30 + i * 28
            l.Y = 30

            Dim myTB As New PictureBox
            myTB.Image = Image.FromFile("picts\empty01.jpg")
            myTB.Width = 27
            myTB.Height = 27
            myTB.Location = l
            myTB.Name = "PB" + i.ToString  ' <- important for later accessing
            Me.Controls.Add(myTB)


        Next
    End Sub

    Private Sub PB01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB01.Click, PB02.Click, PB03.Click, PB04.Click, PB05.Click, PB06.Click, PB07.Click, PB08.Click, PB09.Click, PB10.Click, PB11.Click, PB12.Click, PB13.Click, PB14.Click, PB15.Click, PB16.Click, PB17.Click, PB18.Click, PB19.Click, PB20.Click, PB21.Click, PB22.Click, PB23.Click, PB24.Click, PB25.Click, PB26.Click, PB27.Click, PB28.Click, PB29.Click, PB30.Click, PB31.Click, PB32.Click, PB33.Click, PB34.Click, PB35.Click, PB36.Click, PB37.Click, PB38.Click, PB39.Click, PB40.Click, PB41.Click, PB42.Click, PB43.Click, PB44.Click, PB45.Click, PB46.Click, PB47.Click, PB48.Click, PB49.Click, PB50.Click, PB51.Click, PB52.Click, PB53.Click, PB54.Click, PB55.Click, PB56.Click, PB57.Click, PB58.Click, PB59.Click, PB60.Click, PB61.Click, PB62.Click, PB63.Click, PB64.Click, PB65.Click, PB66.Click, PB67.Click, PB68.Click, PB69.Click, PB70.Click, PB71.Click, PB72.Click, PB73.Click, PB74.Click, PB75.Click, PB76.Click, PB77.Click, PB78.Click, PB79.Click, PB80.Click, PB81.Click, PB82.Click, PB83.Click, PB84.Click, PB85.Click, PB86.Click, PB87.Click, PB88.Click, PB89.Click, PB90.Click, PB91.Click, PB92.Click, PB93.Click, PB94.Click, PB95.Click, PB96.Click
        Dim str As String
        Dim btn As PictureBox
        btn = CType(sender, PictureBox)

        MsgBox("you clicked button: " + btn.Name)


    End Sub


End Class
