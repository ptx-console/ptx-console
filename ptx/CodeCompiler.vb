Imports System.IO
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections.Specialized
Public Class VBNetCompiler

    'Files to compile
    Protected mFilesToCompile As New  _
      System.Collections.Specialized.StringCollection

    'Referenced assemblies
    Protected mImportedDlls As New StringCollection

    'Compiler output
    Protected mVBCompilerResults As CompilerResults
    'Compiler errors
    Protected mVBCompilerErrors As CompilerErrorCollection
    'Compiler parameters
    Protected mVBCompilerParameters As New CompilerParameters

    ''' Constructor
    Public Sub New(ByVal ParamArray pFilesToCompile() As String)
        mFilesToCompile = New System.Collections.Specialized.StringCollection
        For Each oFile As String In pFilesToCompile
            mFilesToCompile.Add(oFile)
        Next
    End Sub

    ''' Constructor
    Public Sub New()
    End Sub

    ''' Files to compile
    Public Property FilesToCompile() As  _
          System.Collections.Specialized.StringCollection
        Get
            Return mFilesToCompile
        End Get
        Set(ByVal Value As System.Collections.Specialized.StringCollection)
            mFilesToCompile = Value
        End Set
    End Property

    ''' Compiler parameters
    Public Property VBCompilerParameters() As CompilerParameters
        Get
            Return mVBCompilerParameters
        End Get
        Set(ByVal Value As CompilerParameters)
            mVBCompilerParameters = Value
        End Set
    End Property

    ''' Compiler errors
    Public ReadOnly Property VBCompilerErrors() As CompilerErrorCollection
        Get
            Return mVBCompilerErrors
        End Get
    End Property

    ''' Compiler output
    Public ReadOnly Property VBCompilerResults() As CompilerResults
        Get
            Return mVBCompilerResults
        End Get
    End Property


    ''' Referenced assemblies
    Public Property ImportedDlls() As StringCollection
        Get
            Return mImportedDlls
        End Get
        Set(ByVal Value As StringCollection)
            mImportedDlls = Value
        End Set
    End Property

    ''' Compiles the code
    Public Function Compile() As CompilerResults
        Dim oVBCodeProvider As New VBCodeProvider
        Dim oVBCodeCompiler As ICodeCompiler
        Dim oVBCompilerResults As CompilerResults
        Dim oVBCompilerError As CompilerError

        oVBCodeCompiler = oVBCodeProvider.CreateCompiler

        With mVBCompilerParameters
            With .ReferencedAssemblies
                For Each oDll As String In mImportedDlls
                    ' adds assembly reference
                    .Add(oDll)
                Next
            End With
        End With

        'Compiling process
        Dim oFiles() As String
        ReDim oFiles(mFilesToCompile.Count - 1)
        mFilesToCompile.CopyTo(oFiles, 0)
        oVBCompilerResults = _
         oVBCodeCompiler.CompileAssemblyFromFileBatch(mVBCompilerParameters, _
         oFiles)


        mVBCompilerResults = oVBCompilerResults
        With oVBCompilerResults
            'Console.WriteLine("---------------------------------")
            'Console.WriteLine("COMPILER OUTPUT: ")
            'Console.WriteLine("---------------------------------")
            'For Each oOut As String In .Output
            '    Console.WriteLine(oOut)
            'Next
        End With

        With oVBCompilerResults
            'Console.WriteLine("---------------------------------")
            'Console.WriteLine("COMPILER ERRORS: " & .Errors.Count)
            'Console.WriteLine("---------------------------------")

            mVBCompilerErrors = .Errors
            Dim ErrorLog As String
            For Each oVBCompilerError In .Errors
                ErrorLog += oVBCompilerError.ToString & vbNewLine
                'Console.WriteLine(oVBCompilerError.ToString)
            Next
            If .Errors.Count > 0 Then
                Throw New Exception("The compiler has thrown the following errors:" & _
                       vbNewLine & ErrorLog)
            End If
        End With

        Return oVBCompilerResults
    End Function

End Class