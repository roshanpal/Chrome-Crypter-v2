﻿Imports System.CodeDom.Compiler
Public Class dwqeEQE3Q2

    Public Shared Sub edasr232222dF(ByVal ASDASD As String, ByVal AS432RE324 As String, ByVal AS432RE32433333333 As String)
        On Error Resume Next

        Dim DQWEQ23DA As ICodeCompiler = (New VBCodeProvider).CreateCompiler()
        Dim DQWEQ23DAAAAAAA As New CompilerParameters()
        Dim DQYTJTYHJTYJ As CompilerResults

        DQWEQ23DAAAAAAA.GenerateExecutable = True
        DQWEQ23DAAAAAAA.OutputAssembly = ASDASD
        DQWEQ23DAAAAAAA.CompilerOptions = "/filealign:0x00000200 /optimize+ /platform:X86 /debug- /target:winexe"
        DQWEQ23DAAAAAAA.ReferencedAssemblies.Add("System.dll")
        DQWEQ23DAAAAAAA.ReferencedAssemblies.Add("System.Data.dll")
        DQWEQ23DAAAAAAA.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        DQWEQ23DAAAAAAA.EmbeddedResources.Add("KMCwauTPggOARWEckhFx.resources")

        Dim FASFASFFF = New Dictionary(Of String, String)
        FASFASFFF.Add("CompilerVersion", "v2.0")



        Dim ADAS432RAS As String = IO.Path.GetTempPath & "\iCompiler.ico"

        If AS432RE32433333333 <> "" Then
            IO.File.Copy(AS432RE32433333333, ADAS432RAS)
            DQWEQ23DAAAAAAA.CompilerOptions &= " /win32icon:" & ADAS432RAS
        End If

        DQYTJTYHJTYJ = DQWEQ23DA.CompileAssemblyFromSource(DQWEQ23DAAAAAAA, AS432RE324)

        If DQYTJTYHJTYJ.Errors.Count > 0 Then
            For Each CompilerError In DQYTJTYHJTYJ.Errors
                MessageBox.Show("Error: " & CompilerError.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Next
        ElseIf DQYTJTYHJTYJ.Errors.Count = 0 Then

        End If
        If AS432RE32433333333 <> "" Then : IO.File.Delete(ADAS432RAS) : End If
    End Sub
End Class