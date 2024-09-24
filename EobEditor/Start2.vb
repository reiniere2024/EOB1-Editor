Imports System.IO

Public Class Start2
    Public StartX As Integer = 300
    Public StartY As Integer = 30
    Public PicWidth As Integer = 20
    Public WinHeight As Integer = 720
    Public WinWidth As Integer = 1000
    Public LocLevel As Integer = 1459
    Public LocPosition As Integer = 1461
    Public LocPosition2 As Integer = 1462
    Public EmptyImage As String = "picts\empty.jpg"
    Public RoadImage As String = "picts\roadB.jpg"
    Public StartImage As String = "picts\startB.jpg"
    Public StairsImage As String = "picts\stairsB.jpg"
    Public CurrentImage As String = "picts\currentB.jpg"
    Public NewImage As String = "picts\newB.jpg"

    Public CurrentPosition As Integer = 0
    Public CurrentTag As Integer = 0
    Public CurrentClicked As Integer = 0
    Public CurrentClickedTag As Integer = 0
    Public CurSavegameSelected As Integer = 0

    Public CurrentSaveGame As Integer = 1
    Public CurrentSaveGameName As String = "EOBDATA.SAV"
    Public GameFolder As String = ""

    Public LevelSelectedMap As Integer = -1
    Public LevelSavegameMap As Integer = -1

    Public MyPictures(1024) As PictureBox
    Public MyFields(1024) As Integer
    Public ds As New DataSet

    'Public MyFields(2, 32) As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}


    Private Sub Start2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Width = WinWidth
        Me.Height = WinHeight
        Me.Location = New Point(0, 0)

        'Read Game Settings in EOB.XML
        ds.ReadXml(CurDir() + "\xml\eob1.xml")
        GameFolder = ds.Tables(0).Rows(0).Item(0)
        TextBox1.Text = GameFolder

        Me.CreateControls()

        'Me.FillMaps(1)
        'LevelSelectedMap = 0
        'Me.InitializeFields()

        't_level2.Text = "0"
        't_lvlname2.Text = "Wood Level"

    End Sub

    Public Sub FillMaps(ByVal mapnr As Integer)

        Select Case mapnr
            Case 1
                For i = 0 To 1023
                    MyFields(i) = MyFields1(i)
                Next
            Case 2
                For i = 0 To 1023
                    MyFields(i) = MyFields2(i)
                Next
            Case 3
                For i = 0 To 1023
                    MyFields(i) = MyFields3(i)
                Next
            Case 4
                For i = 0 To 1023
                    MyFields(i) = MyFields4(i)
                Next
            Case 5
                For i = 0 To 1023
                    MyFields(i) = MyFields5(i)
                Next
            Case 6
                For i = 0 To 1023
                    MyFields(i) = MyFields6(i)
                Next
            Case 7
                For i = 0 To 1023
                    MyFields(i) = MyFields7(i)
                Next
            Case 8
                For i = 0 To 1023
                    MyFields(i) = MyFields8(i)
                Next
            Case 9
                For i = 0 To 1023
                    MyFields(i) = MyFields9(i)
                Next
            Case 10
                For i = 0 To 1023
                    MyFields(i) = MyFields10(i)
                Next
            Case 11
                For i = 0 To 1023
                    MyFields(i) = MyFields11(i)
                Next
            Case 12
                For i = 0 To 1023
                    MyFields(i) = MyFields12(i)
                Next

        End Select


    End Sub

    Public Sub InitializeFields()

        For i As Integer = 0 To 1023
            MyPictures(i).Image = Image.FromFile(EmptyImage)
            'MyPictures(i).BorderStyle = BorderStyle.FixedSingle
        Next

        For i As Integer = 0 To 1023

            If MyFields(i) <> 0 Then
                Me.AddImage(i, MyFields(i))
            End If

        Next

    End Sub

    Public Sub AddImage(ByVal pict As Integer, ByVal pictnum As Integer)

        Select Case pictnum

            Case 0
                MyPictures(pict).Image = Image.FromFile(EmptyImage)
                MyPictures(pict).Tag = "0"

            Case 1
                MyPictures(pict).Image = Image.FromFile(RoadImage)
                MyPictures(pict).Tag = "1"

            Case 2
                MyPictures(pict).Image = Image.FromFile(StartImage)
                MyPictures(pict).Tag = "2"

            Case 5
                MyPictures(pict).Image = Image.FromFile(StairsImage)
                MyPictures(pict).Tag = "5"

        End Select

        'MyPictures(pict).Image = Image.FromFile("picts\road01.jpg")

    End Sub


    Public Sub CreateControls()
        Dim l As Point

        l.X = StartX
        l.Y = StartY

        For i As Integer = 0 To 1023
            l.X = l.X + PicWidth

            Dim myTB As PictureBox
            Me.MyPictures(i) = New PictureBox
            myTB = MyPictures(i)
            myTB.Image = Image.FromFile(EmptyImage)
            myTB.Tag = "0"
            myTB.Width = PicWidth
            myTB.Height = PicWidth
            myTB.Location = l
            myTB.BorderStyle = BorderStyle.None
            myTB.Name = "PB" + i.ToString  ' <- important for later accessing
            'myTB.SizeMode = PictureBoxSizeMode.StretchImage
            Me.Controls.Add(myTB)
            AddHandler MyPictures(i).Click, AddressOf Me.ClickButton

            If ((i + 1) Mod 32) = 0 Then
                l.Y = l.Y + PicWidth
                l.X = StartX

            End If


        Next

        'AddHandler MyPictures(0).Click, AddressOf Me.ClickButton



    End Sub

    Private Sub ClickButton(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim str As String
        Dim ind As Integer
        Dim btn As PictureBox
        btn = CType(sender, PictureBox)

        str = btn.Name
        str = str.Substring(2, str.Length - 2)
        ind = CInt(str)
        If CurrentClicked > 0 Then
            Me.AddImage(CurrentClicked, CurrentClickedTag)
        End If
        CurrentClicked = ind
        CurrentClickedTag = MyPictures(CurrentClicked).Tag
        MyPictures(CurrentClicked).Image = Image.FromFile(NewImage)
        t_position2.Text = CurrentClicked.ToString()


        'MsgBox("you clicked button: " + str)


    End Sub

    Private Sub LoadSaveGame()

        If CurrentSaveGame = 0 Then
            MsgBox("No savegame selected. Please select a savegame first !!!")
            Return

        End If

        Dim FilName As String
        Dim sItem, sFile, sItemHex, sItemTwo, myname As String
        Dim CurPosition As Integer

        FilName = TextBox1.Text
        FilName = FilName + "\" + CurrentSaveGameName

        'Level of the SaveGame
        sItem = Me.ReadFileChar(FilName, LocLevel)
        If sItem = "" Then Return

        t_level.Text = sItem
        t_lvlname.Text = GetLevel(sItem)

        'Position in the SaveGame
        sItem = Me.ReadFileChar(FilName, LocPosition)
        If sItem = "" Then Return

        sItemHex = Hex(sItem)
        If sItemHex.Length < 2 Then
            sItemHex = "0" + sItemHex
        End If
        t_hex.Text = sItemHex

        'Position Byte 2 in the SaveGame
        sItemTwo = Me.ReadFileChar(FilName, LocPosition2)
        If sItemTwo = "" Then Return

        t_hex2.Text = sItemTwo

        CurPosition = Me.CalculatePosition(sItemHex, sItemTwo)
        If CurrentPosition > 0 Then
            MyPictures(CurrentPosition).Image = Image.FromFile(RoadImage)
        End If
        MyPictures(CurPosition).Image = Image.FromFile(CurrentImage)
        CurrentPosition = CurPosition


    End Sub

    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load.Click

        Me.LoadSaveGame()

    End Sub

    Private Function GetLevel(ByVal level As String) As String
        Dim mylevel As String

        Select Case level

            Case 1
                mylevel = "Upper Sewer Level"
                LevelSavegameMap = 1
            Case 2
                mylevel = "Middle Sewer Level"
                LevelSavegameMap = 2
            Case 3
                mylevel = "Lower Sewer Level"
                LevelSavegameMap = 3

            Case "4"
                mylevel = "Upper Level Dwarven Ruins"
                LevelSavegameMap = 0
            Case "5"
                mylevel = "Dwarven Ruins and Camp"
                LevelSavegameMap = 5
            Case "6"
                mylevel = "Bottom Level of Dwarven Ruins"
                LevelSavegameMap = 6
            Case "7"
                mylevel = "Upper Reaches of the Drow"
                LevelSavegameMap = 7
            Case "8"
                mylevel = "Drow Outcasts"
                LevelSavegameMap = 8
            Case "9"
                mylevel = "Lower Reaches of the Drow"
                LevelSavegameMap = 9
            Case "10"
                mylevel = "Xanthars Outer Sanctum, Mantis Hive"
                LevelSavegameMap = 10
            Case "11"
                mylevel = "Xanthars Outer Sanctum, Lower Reaches"
                LevelSavegameMap = 11
            Case "12"
                mylevel = "Xanthars Inner Sanctum"
                LevelSavegameMap = 12

        End Select

        Return mylevel


    End Function

    Private Function ReadFileChar(ByVal filnam As String, ByVal location As Integer) As String
        Dim pos As Integer = 0
        Dim sItem, sFile As String

        Try

            Dim FS As New FileStream(filnam, FileMode.Open, FileAccess.Read)
            Dim SR As New BinaryReader(FS)

            Do While pos < location
                sItem = SR.ReadByte()
                pos += 1
            Loop


            SR.Close()
            FS.Close()

            Return sItem

        Catch ex As Exception

            MsgBox("Savegame " + CurrentSaveGameName + " not found. Please generate a savegame in EOB2 !!!")
            Return ""

        End Try



    End Function


    Private Function CalculatePosition(ByVal str As String, ByVal row As String) As Integer
        Dim sItem, sItemHex As String
        Dim char1, char2 As Char
        Dim pos1, pos2, pos As Integer

        char1 = str.Substring(0, 1)
        char2 = str.Substring(1, 1)

        pos1 = hextodigit(char1)
        pos2 = hextodigit(char2)
        pos = ((pos1 * 16) + pos2)
        Select Case row
            Case 1
                pos = pos + 256
                pos1 = pos1 + 8
            Case 2
                pos = pos + 512
                pos1 = pos1 + 16
            Case 3
                pos = pos + 768
                pos1 = pos1 + 24
        End Select

        t_position.Text = pos.ToString()
        t_pos1.Text = pos1.ToString()
        t_pos2.Text = pos2.ToString()

        Return pos


    End Function

    Private Function hextodigit(ByVal mychar As Char) As Integer
        Dim mypos As Integer

        Select Case mychar

            Case "0"
                mypos = 0
            Case "1"
                mypos = 1
            Case "2"
                mypos = 2
            Case "3"
                mypos = 3
            Case "4"
                mypos = 4
            Case "5"
                mypos = 5
            Case "6"
                mypos = 6
            Case "7"
                mypos = 7
            Case "8"
                mypos = 8
            Case "9"
                mypos = 9
            Case "A"
                mypos = 10
            Case "B"
                mypos = 11
            Case "C"
                mypos = 12
            Case "D"
                mypos = 13
            Case "E"
                mypos = 14
            Case "F"
                mypos = 15
        End Select

        Return mypos

    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c_level.SelectedIndexChanged
        Dim i As Integer
        Dim str As String

        str = c_level.Text

        Select Case str
            Case "01: Upper Sewer Level"
                Me.FillMaps(1)
                Me.InitializeFields()
                LevelSelectedMap = 1
                t_level2.Text = "0"
                t_lvlname2.Text = "Upper Sewer Level"
            Case "02: Middle Sewer Level"
                Me.FillMaps(2)
                Me.InitializeFields()
                LevelSelectedMap = 2
                t_lvlname2.Text = "Middle Sewer Level"
            Case "03: Lower Sewer Level"
                Me.FillMaps(3)
                Me.InitializeFields()
                LevelSelectedMap = 3
                t_lvlname2.Text = "Lower Sewer Level"
            Case "04: Upper Level Dwarven Ruins"
                Me.FillMaps(4)
                Me.InitializeFields()
                LevelSelectedMap = 4
                t_lvlname2.Text = "Upper Level Dwarven Ruins"
            Case "05: Dwarven Ruins and Camp"
                Me.FillMaps(5)
                Me.InitializeFields()
                LevelSelectedMap = 5
                t_lvlname2.Text = "Dwarven Ruins and Camp"
            Case "06: Bottom Level of Dwarven Ruins"
                Me.FillMaps(6)
                Me.InitializeFields()
                LevelSelectedMap = 6
                t_lvlname2.Text = "Bottom Level of Dwarven Ruins"
            Case "07: Upper Reaches of the Drow"
                Me.FillMaps(7)
                Me.InitializeFields()
                LevelSelectedMap = 7
                t_lvlname2.Text = "Upper Reaches of the Drow"
            Case "08: Drow Outcasts"
                Me.FillMaps(8)
                Me.InitializeFields()
                LevelSelectedMap = 8
                t_lvlname2.Text = "Drow Outcasts"
            Case "09: Lower Reaches of the Drow"
                Me.FillMaps(9)
                Me.InitializeFields()
                LevelSelectedMap = 9
                t_lvlname2.Text = "Lower Reaches of the Drow"
            Case "10: Xanthars Outer Sanctum, Mantis Hive"
                Me.FillMaps(10)
                Me.InitializeFields()
                LevelSelectedMap = 10
                t_lvlname2.Text = "Xanthars Outer Sanctum, Mantis Hive"
            Case "11: Xanthars Outer Sanctum, Lower Reaches"
                Me.FillMaps(11)
                Me.InitializeFields()
                LevelSelectedMap = 11
                t_lvlname2.Text = "Xanthars Outer Sanctum, Lower Reaches"
            Case "12: Xanthars Inner Sanctum"
                Me.FillMaps(12)
                Me.InitializeFields()
                LevelSelectedMap = 12
                t_lvlname2.Text = "Xanthars Inner Sanctum"
        End Select
        t_level2.Text = LevelSelectedMap.ToString()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim rc As Integer

        If CurrentSaveGame = 0 Then
            MsgBox("No savegame selected. Please select a savegame first !!!")
            Return
        End If

        rc = MsgBox("This will update your position in the savegame !" + vbCrLf + "Are you sure wou want to do this ?", MsgBoxStyle.OkCancel)
        If rc = 1 Then
            'MsgBox("ok")
            Me.SavePosition()

        Else

            Return
            'MsgBox("cancel")
        End If

    End Sub


    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click

        RadioButton1.Checked = True


    End Sub

 



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(CurrentSaveGameName)

    End Sub






    Public Sub SavePositionCopyRemoveLater()

        Dim curpos, newpos, newpos2 As Integer
        Dim pos As Integer = 0
        Dim filnam, sItem, sItem2, sItemHex As String
        Dim byte1, byte2 As Byte

        curpos = CurrentPosition
        newpos = CurrentClicked
        If newpos > 767 Then
            newpos = newpos - 768
            newpos2 = 3
        ElseIf newpos > 511 Then
            newpos = newpos - 512
            newpos2 = 2
        ElseIf newpos > 255 Then
            newpos = newpos - 256
            newpos2 = 1
        Else
            newpos2 = 0
        End If
        '256 512 768 1024

        sItem = newpos.ToString()
        sItem2 = newpos2.ToString()

        filnam = TextBox1.Text
        filnam = filnam + "\" + CurrentSaveGameName

        Dim fileStream As IO.FileStream = New IO.FileStream(filnam, IO.FileMode.Open)
        fileStream.Seek(LocPosition - 1, IO.SeekOrigin.Begin)
        fileStream.WriteByte(sItem)
        fileStream.WriteByte(sItem2)

        fileStream.Close()
        CurrentClicked = 0
        CurrentTag = CurrentClickedTag
        Me.LoadSaveGame()

    End Sub


    Public Sub SavePosition()

        Dim curpos, newpos, newpos2 As Integer
        Dim pos As Integer = 0
        Dim filnam, sItem, sItem2, sItemHex As String
        Dim byte1, byte2 As Byte

        curpos = CurrentPosition
        newpos = CurrentClicked
        If newpos > 767 Then
            newpos = newpos - 768
            newpos2 = 3
        ElseIf newpos > 511 Then
            newpos = newpos - 512
            newpos2 = 2
        ElseIf newpos > 255 Then
            newpos = newpos - 256
            newpos2 = 1
        Else
            newpos2 = 0
        End If

        sItem = newpos.ToString()
        sItem2 = newpos2.ToString()

        filnam = TextBox1.Text
        filnam = filnam + "\" + CurrentSaveGameName

        WriteFile(filnam, LocPosition, sItem)
        WriteFile(filnam, LocPosition + 1, sItem2)

        CurrentClicked = 0
        CurrentTag = CurrentClickedTag
        Me.LoadSaveGame()


    End Sub

    Private Sub WriteNewSavegame(ByVal name As String, ByVal Lvl As String, ByVal Item As String, ByVal Item2 As String)

        Dim filnam As String

        filnam = TextBox1.Text
        filnam = filnam + "\" + CurrentSaveGameName

        If name <> "" Then
            WriteFileString(filnam, 0, name)
        End If

        WriteFile(filnam, LocLevel, Lvl)
        WriteFile(filnam, LocPosition, Item)
        WriteFile(filnam, LocPosition + 1, Item2)


    End Sub

    Private Sub WriteFileString(ByVal fnam As String, ByVal pos As Integer, ByVal item As String)
        Dim loc, l2 As Integer
        Dim str, strasci, strhex As String

        If pos = 0 Then
            loc = 0
        Else
            loc = pos - 1
        End If

        Dim fileStream As IO.FileStream = New IO.FileStream(fnam, IO.FileMode.Open)
        fileStream.Seek(loc, IO.SeekOrigin.Begin)

        For i = 0 To item.Length - 1
            str = item.Substring(i, 1)
            strasci = Asc(str)
            fileStream.WriteByte(strasci)
        Next
        fileStream.Close()

    End Sub

    Private Sub WriteFile(ByVal fnam As String, ByVal pos As Integer, ByVal item As String)

        Dim fileStream As IO.FileStream = New IO.FileStream(fnam, IO.FileMode.Open)
        fileStream.Seek(pos - 1, IO.SeekOrigin.Begin)
        fileStream.WriteByte(item)
        fileStream.Close()


    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SavePosition()

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If CurrentSaveGame = 0 Then
            MsgBox("No savegame selected. Please load a savegame first !!!")
            Return
        End If

        If c_newlevel.Text = "" Then
            MsgBox("No new level selected. Please select a a new level first !!!")
            Return
        End If

        Me.NewLevelSavegame("", c_newlevel.Text)
        MsgBox("New level is saved. Please select this map and then reopen the savegame !!!")


    End Sub

    Private Sub NewLevelSavegame(ByVal name As String, ByVal str As String)

        Dim sItem, sItem2, sLvl As String

        Select Case str

            Case "01: Upper Sewer Level" 'EA 01
                sLvl = 1
                sItem = 234
                sItem2 = 1
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "02: Middle Sewer Level" 'F3 02
                sLvl = 2
                sItem = 243
                sItem2 = 2
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "03: Lower Sewer Level" '9A 00
                sLvl = 3
                sItem = 154
                sItem2 = 0
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "04: Upper Level Dwarven Ruins" 'D0 01
                sLvl = 4
                sItem = 208
                sItem2 = 1
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "05: Dwarven Ruins and Camp" '0A 03
                sLvl = 5
                sItem = 10
                sItem2 = 3
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "06: Bottom Level of Dwarven Ruins" '38 00
                sLvl = 6
                sItem = 56
                sItem2 = 0
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "07: Upper Reaches of the Drow" '61 02
                sLvl = 7
                sItem = 97
                sItem2 = 2
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "08: Drow Outcasts" '4D 02
                sLvl = 8
                sItem = 77
                sItem2 = 2
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "09: Lower Reaches of the Drow" '11 02
                sLvl = 9
                sItem = 17
                sItem2 = 2
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "10: Xanthars Outer Sanctum, Mantis Hive" '85 03
                sLvl = 10
                sItem = 133
                sItem2 = 3
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "11: Xanthars Outer Sanctum, Lower Reaches" '4E 01
                sLvl = 11
                sItem = 78
                sItem2 = 1
                WriteNewSavegame(name, sLvl, sItem, sItem2)
            Case "12: Xanthars Inner Sanctum" '6F 01
                sLvl = 12
                sItem = 111
                sItem2 = 1
                WriteNewSavegame(name, sLvl, sItem, sItem2)

        End Select

    End Sub

    Private Sub cbx_maze_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'If cbx_maze.Checked = True Then
        '    For i As Integer = 0 To 1023
        '        MyPictures(i).BorderStyle = BorderStyle.FixedSingle
        '    Next
        'Else
        '    For i As Integer = 0 To 1023
        '        MyPictures(i).BorderStyle = BorderStyle.None
        '    Next

        'End If

    End Sub
End Class