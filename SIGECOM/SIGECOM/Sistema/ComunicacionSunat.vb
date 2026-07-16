'Imports ICSharpCode.SharpZipLib
Imports UblLarsen.Ubl2.Models
Imports System.ServiceModel.Channels
Imports Ionic.Zip

Public Class ComunicacionSunat

    Public Function EnviarDocumentoSunat(ruta As String, file As String) As Boolean

        Dim resul As Boolean = False
        'Dim ruta As String = "D:\Certificado\"
        'Dim file As String = "20100020441-RC-20150619-1.ZIP"

        Dim local_filereceived As String = ruta & "R-" & file
        ' Dim zip As New ICSharpCode.SharpZipLib.Zip.FastZip


        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())


        System.Net.ServicePointManager.Expect100Continue = False


        Try
            Dim data As Byte() = System.IO.File.ReadAllBytes(ruta & file)
            'Dim ws As New SunatService.billServiceClient


            'SERVICIO PARA PRUEBAS
            ' Dim ws As New SunatBetaService.billServiceClient("BillServicePort1")

            'SERVICIOS DE HOMOLOGACION
            'Dim ws As New SunatService.billServiceClient("BillServicePort")

            'SERVICIO EN PRODUCCION

            Dim ws As New SunatProduccionService.billServiceClient("BillServicePort2")

            ws.Endpoint.Binding = binding

            Dim Retour As Byte()

            ws.Open()

            ws.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            'ENVIAR ARCHIVO A LA SUNAT
            Retour = ws.sendBill(file, data, "Lima - Peru")
            '///////////////////////////////////


            'DESCARGAR LA RESPUESTA
            System.IO.File.WriteAllBytes(local_filereceived, Retour)

            'DESCOMPRIMIR EL CDR ZIPIADO PARA LLER EL XML
            '   zip.ExtractZip(local_filereceived, ruta, "")           
            Using zip As ZipFile = ZipFile.Read(local_filereceived)
                zip.ExtractAll(ruta)
                zip.Dispose()
            End Using

            ws.Close()
            'Suprimer los archivos ZIP recibidos
            'System.IO.File.Delete(local_filereceived)
            'System.IO.File.Delete(local_filereceived)

            ' MsgBox("Se proceso con exito")

            resul = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resul

    End Function

    Public Function EnviarDocumentoIquitosSunat(ruta As String, file As String) As Boolean

        Dim resul As Boolean = False
        'Dim ruta As String = "D:\Certificado\"
        'Dim file As String = "20100020441-RC-20150619-1.ZIP"

        Dim local_filereceived As String = ruta & "R-" & file
        ' Dim zip As New ICSharpCode.SharpZipLib.Zip.FastZip


        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())


        System.Net.ServicePointManager.Expect100Continue = False


        Try
            Dim data As Byte() = System.IO.File.ReadAllBytes(ruta & file)
            'Dim ws As New SunatService.billServiceClient


            'SERVICIO PARA PRUEBAS
            ' Dim ws As New SunatBetaService.billServiceClient("BillServicePort1")

            'SERVICIOS DE HOMOLOGACION
            'Dim ws As New SunatService.billServiceClient("BillServicePort")

            'SERVICIO EN PRODUCCION

            Dim ws As New SunatProduccionIquitosService.billServiceClient("BillServicePort5")

            ws.Endpoint.Binding = binding

            Dim Retour As Byte()

            ws.Open()

            ws.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            'ENVIAR ARCHIVO A LA SUNAT
            Retour = ws.sendBill(file, data, "Lima - Peru")
            '///////////////////////////////////


            'DESCARGAR LA RESPUESTA
            System.IO.File.WriteAllBytes(local_filereceived, Retour)

            'DESCOMPRIMIR EL CDR ZIPIADO PARA LLER EL XML
            '   zip.ExtractZip(local_filereceived, ruta, "")           
            Using zip As ZipFile = ZipFile.Read(local_filereceived)
                zip.ExtractAll(ruta)
                zip.Dispose()
            End Using

            ws.Close()
            'Suprimer los archivos ZIP recibidos
            'System.IO.File.Delete(local_filereceived)
            'System.IO.File.Delete(local_filereceived)

            ' MsgBox("Se proceso con exito")

            resul = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resul

    End Function

    Public Function EnviarSummarySunat(ruta As String, file As String) As String
        'Dim ruta As String = "D:\Certificado\"
        'Dim file As String = "20100020441-01-FF11-47803.ZIP"

        Dim nTicket As String = ""

        Dim local_filereceived As String = ruta & "R-" & file
        'Dim zip As New ICSharpCode.SharpZipLib.Zip.FastZip


        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())
        System.Net.ServicePointManager.Expect100Continue = False

        Try
            Dim data As Byte() = System.IO.File.ReadAllBytes(ruta & file)

            'SERVICIO PARA PRUEBAS
            'Dim ws As New SunatBetaService.billServiceClient("BillServicePort1")

            'SERVICIOS DE HOMOLOGACION
            'Dim ws As New SunatService.billServiceClient("BillServicePort")

            'SERVICIO EN PRODUCCION
            Dim ws As New SunatProduccionService.billServiceClient("BillServicePort2")


            ws.Endpoint.Binding = binding
            ws.Open()

            ws.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)

            'ENVIAR ARCHIVO A LA SUNAT
            nTicket = ws.sendSummary(file, data, "Lima - Peru")
            '//////////////////////////////////////////////

            ws.Close()

            '  MsgBox("Se proceso con exito")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return nTicket

    End Function

    Public Function ObtenerEstadoSunat(ruta As String, file As String, nTicket As String) As Boolean

        'Dim ruta As String = "D:\Certificado\"
        'Dim file As String = "20100020441-01-FF11-47803.ZIP"

        Dim resul As Boolean = False


        Dim local_filereceived As String = ruta & "R-" & file
        'Dim zip As New ICSharpCode.SharpZipLib.Zip.FastZip



        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())

        System.Net.ServicePointManager.Expect100Continue = False

        Try
            'SERVICIO PARA PRUEBAS
            'Dim ws As New SunatBetaService.billServiceClient("BillServicePort1")

            'SERVICIOS DE HOMOLOGACION
            'Dim ws As New SunatService.billServiceClient("BillServicePort")

            'SERVICIO EN PRODUCCION
            Dim ws As New SunatProduccionService.billServiceClient("BillServicePort2")

            ws.Endpoint.Binding = binding

            Dim Retour As Byte()


            ws.Open()

            ws.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)

            'RECIBIR ESTADO Y EL CDR DEL PROCESO DE RESPUESTA SUNAT
            Retour = ws.getStatus(nTicket).content
            'Me.TextBox1.Text = ws.getStatus(nTicket).statusCode
            ''//////////////////////////////////////////////

          
            'GRABAR LA RESPUESTA EN LA RUTA INDICADA
            System.IO.File.WriteAllBytes(local_filereceived, Retour)

            'DESCOMPRIMIR EL CDR ZIPIADO PARA LLER EL XML
            '   zip.ExtractZip(local_filereceived, ruta, "")           
            Using zip As ZipFile = ZipFile.Read(local_filereceived)
                zip.ExtractAll(ruta)
                zip.Dispose()
            End Using

            ws.Close()
            'SUPRIMIR LOS ARCHIVOS RECIBIDOS
            'System.IO.File.Delete(local_filereceived)
            'System.IO.File.Delete(local_filereceived)

            ' MsgBox("Se proceso con exito")

            resul = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resul

    End Function

    Public Function ObtenerCDR(Ruta As String, NombreArchivo As String, Ruc As String, TipoDoc As String, Serie As String, Numero As Int64) As Boolean

        
        Dim resul As Boolean = False


        Dim local_filereceived As String = Ruta & "R-" & NombreArchivo




        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())

        System.Net.ServicePointManager.Expect100Continue = False

        Try
           
            'SERVICIO DE CONSULTA
            Dim ws As New SunatConsultaService.billServiceClient("BillConsultServicePort")

            ws.Endpoint.Binding = binding

            Dim Retour As Byte()


            ws.Open()

            'RECIBIR CDR SUNAT DEL DOCUMENTO
            Retour = ws.getStatusCdr(Ruc, TipoDoc, Serie, Numero).content
            ''//////////////////////////////////////////////

            'GRABAR CDR EN LA RUTA INDICADA
            System.IO.File.WriteAllBytes(local_filereceived, Retour)

            'DESCOMPRIMIR EL CDR 
            Using zip As ZipFile = ZipFile.Read(local_filereceived)
                zip.ExtractAll(ruta)
                zip.Dispose()
            End Using

            ws.Close()
            

            resul = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resul

    End Function

    Public Function ObtenerMensajeEstado(Ruc As String, TipoDoc As String, Serie As String, Numero As Int64) As String

        Dim mensaje As String = ""

        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())
        System.Net.ServicePointManager.Expect100Continue = False

        Try

            'SERVICIO DE CONSULTA
            Dim ws As New SunatConsultaService.billServiceClient("BillConsultServicePort")


            ws.Endpoint.Binding = binding
            ws.Open()

            'OBTENER MENSAJE DEL ESTADO DEL DOCUMENTO EN SUNAT
            mensaje = ws.getStatus(Ruc, TipoDoc, Serie, Numero).statusMessage
            '//////////////////////////////////////////////

            ws.Close()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return mensaje

    End Function

    Public Function EnviarGuiaRemisionSunat(ruta As String, file As String) As Boolean

        Dim resul As Boolean = False
        'Dim ruta As String = "D:\Certificado\"
        'Dim file As String = "20100020441-RC-20150619-1.ZIP"

        Dim local_filereceived As String = ruta & "R-" & file
        ' Dim zip As New ICSharpCode.SharpZipLib.Zip.FastZip


        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())


        System.Net.ServicePointManager.Expect100Continue = False


        Try
            Dim data As Byte() = System.IO.File.ReadAllBytes(ruta & file)
            'Dim ws As New SunatService.billServiceClient


            'SERVICIO PARA PRUEBAS
            'Dim ws As New SunatGuiaBetaService.billServiceClient("BillServicePort7")

            'SERVICIO EN PRODUCCION

            Dim ws As New SunatServiceGuiaService.billServiceClient("BillServicePort7")

            ws.Endpoint.Binding = binding

            Dim Retour As Byte()

            ws.Open()

            ws.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            'ENVIAR ARCHIVO A LA SUNAT
            Retour = ws.sendBill(file, data, "Lima - Peru")
            '///////////////////////////////////


            'DESCARGAR LA RESPUESTA
            System.IO.File.WriteAllBytes(local_filereceived, Retour)

            'DESCOMPRIMIR EL CDR ZIPIADO PARA LLER EL XML
            '   zip.ExtractZip(local_filereceived, ruta, "")           
            Using zip As ZipFile = ZipFile.Read(local_filereceived)
                zip.ExtractAll(ruta)
                zip.Dispose()
            End Using

            ws.Close()
            'Suprimer los archivos ZIP recibidos
            'System.IO.File.Delete(local_filereceived)
            'System.IO.File.Delete(local_filereceived)

            ' MsgBox("Se proceso con exito")

            resul = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resul

    End Function

    Public Function EnviarDocumentoOSE(ruta As String, file As String) As Boolean

        Dim resul As Boolean = False
        'Dim ruta As String = "D:\Certificado\"
        'Dim file As String = "20100020441-RC-20150619-1.ZIP"

        Dim local_filereceived As String = ruta & "R-" & file
        ' Dim zip As New ICSharpCode.SharpZipLib.Zip.FastZip


        Dim binding As New CustomBinding(
            New CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
            New HttpsTransportBindingElement())


        System.Net.ServicePointManager.Expect100Continue = False


        Try
            Dim data As Byte() = System.IO.File.ReadAllBytes(ruta & file)
            'Dim ws As New SunatService.billServiceClient


            'SERVICIO PARA PRUEBAS
            ' Dim ws As New SunatBetaService.billServiceClient("BillServicePort1")

            'SERVICIOS DE HOMOLOGACION
            'Dim ws As New SunatService.billServiceClient("BillServicePort")

            'SERVICIO EN PRODUCCION

            Dim ws As New OSEService.BillServiceClient("BillServiceImplPort")

            ws.ClientCredentials.UserName.UserName = "20100020441"
            ws.ClientCredentials.UserName.Password = "ncVI2Q7Uxb"

            ws.Endpoint.Binding = binding

            Dim Retour As Byte()

            ws.Open()

            ws.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            'ENVIAR ARCHIVO A LA SUNAT
            Retour = ws.sendBill(file, data)
            '///////////////////////////////////


            'DESCARGAR LA RESPUESTA
            System.IO.File.WriteAllBytes(local_filereceived, Retour)

            'DESCOMPRIMIR EL CDR ZIPIADO PARA LLER EL XML
            '   zip.ExtractZip(local_filereceived, ruta, "")           
            Using zip As ZipFile = ZipFile.Read(local_filereceived)
                zip.ExtractAll(ruta)
                zip.Dispose()
            End Using

            ws.Close()
            'Suprimer los archivos ZIP recibidos
            'System.IO.File.Delete(local_filereceived)
            'System.IO.File.Delete(local_filereceived)

            ' MsgBox("Se proceso con exito")

            resul = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resul

    End Function

End Class
