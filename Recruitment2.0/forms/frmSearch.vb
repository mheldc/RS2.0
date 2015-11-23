Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frmSearch
    Dim SourceForm As Form

    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function LoadSeachItems(ByVal SourceObj As Form) As Integer
        SourceForm = SourceObj
        dgvSearchItems.DataSource = Nothing
        Dim ItemId As Integer = 0
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Try
                Select Case SourceObj.Name
                    Case "frmDepartment"
                        Qry = "select `dp_id`, `deptcode`, `deptname`, `description` from hrs_departments where `recstatus` = 1;"
                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Nothing, CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "Department Id", False, False, True, 50, , DataGridViewContentAlignment.MiddleCenter)
                            FormatGridColumn(dgvSearchItems, 2, "Department Code", False, True, True, 150, , DataGridViewContentAlignment.MiddleCenter)
                            FormatGridColumn(dgvSearchItems, 3, "Department Name", False, True, True, 200, , DataGridViewContentAlignment.MiddleCenter)
                            FormatGridColumn(dgvSearchItems, 4, "Description", False, True, True, 300, , DataGridViewContentAlignment.MiddleCenter)
                        End With

                    Case "frmClientProfile"
                        Qry = "select `ca_id`, `accountcode`, `accountname` from `rms_clientaccounts` where `recstatus` = 1;"
                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Nothing, CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "Account Id", False, False, True, 50, , DataGridViewContentAlignment.MiddleCenter)
                            FormatGridColumn(dgvSearchItems, 2, "Account Code", False, True, True, 150, , DataGridViewContentAlignment.MiddleCenter)
                            FormatGridColumn(dgvSearchItems, 3, "Account Name", False, True, True, 300, , DataGridViewContentAlignment.MiddleCenter)
                        End With

                    Case "frmCandidateProfile"
                        Qry = <Command>
                                    select 
				                        `ci_id`, `referenceid`,
				                            concat(`lastname`, ', ', `firstname`, case length(`middlename`) when 0 then '' else concat(' ' , substr(middlename,1,1) , '.') end) as fullname,
				                            case `recstatus` when 0 then 'Deleted / For Purging' else 'Active' end recstatus
			                        from rms_candidateinfo
                                    where `recstatus` = 1;
                              </Command>.Value

                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Nothing, CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 2, "Reference Id", True, True, True, 150)
                            FormatGridColumn(dgvSearchItems, 3, "Candidate Name", True, True, True, 250)
                            FormatGridColumn(dgvSearchItems, 4, "Status", True, True, True, 100)
                        End With

                    Case "frmCandidateSource"
                        Qry = "select `cs_id`, `sourcecode`, `description` from `rms_candidatesource` where `recstatus` = 1;"
                        Dset = New DataSet
                        Dset = Query(Qry, Cn, , CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "Source Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 2, "Code", False, True, True, 150)
                            FormatGridColumn(dgvSearchItems, 3, "Description", False, True, True, 300)
                        End With

                    Case "frmSkillType"
                        Qry = "select `st_id`, `typecode`, `description` from `rms_skilltypes` where `recstatus` = 1;"
                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Nothing, CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "Type Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 2, "Code", True, True, True, 150)
                            FormatGridColumn(dgvSearchItems, 3, "Description", True, True, True, 250)
                        End With

                    Case "frmSkillGroup"
                        Qry = <Query>
                                    select a.`sg_id`, a.`st_id`, a.`groupcode`, a.`description` as skillgroup, b.`description` as skilltype
                                    from 			`rms_skillgroups` as a
	                                    inner join	`rms_skilltypes`  as b on a.`st_id` = b.`st_id`
                                    where a.`recstatus` = 1
                                    order by a.`st_id` asc; 
                              </Query>.Value
                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Nothing, CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "Group Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 2, "Type Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 3, "Code", True, True, True, 150)
                            FormatGridColumn(dgvSearchItems, 4, "Group Name", True, True, True, 250)
                            FormatGridColumn(dgvSearchItems, 5, "Skill Type", True, True, True, 250)
                        End With

                    Case "frmSkill"
                        Qry = <Query>
                                    select
	                                    a.`sk_id`, c.`st_id`, b.`sg_id`,  a.`skillcode`, a.`description` as skill, b.`description` as skillgroup, c.`description` as skilltype
                                    from 		   `rms_skills`      as a
	                                    inner join `rms_skillgroups` as b on a.`sg_id` = b.`sg_id`
	                                    inner join `rms_skilltypes`  as c on b.`st_id` = c.`st_id`
                                    where a.`recstatus` = 1 limit 100; 
                              </Query>.Value
                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Nothing, CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "Skill Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 2, "Skill Type Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 3, "Skill Group Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 4, "Code", True, True, True, 150)
                            FormatGridColumn(dgvSearchItems, 5, "Description", True, True, True, 250)
                            FormatGridColumn(dgvSearchItems, 6, "Skill Group", False, True, True, 250)
                            FormatGridColumn(dgvSearchItems, 7, "Skill Type", False, True, True, 250)
                        End With

                    Case "frmSkillLevel"
                        Qry = "select `sl_id`, `levelcode`, `description` from `rms_skilllevels` where `recstatus` = 1;"
                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Nothing, CommandType.Text)
                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "Level Id", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 2, "Code", True, True, True, 150)
                            FormatGridColumn(dgvSearchItems, 3, "Description", True, True, True, 250)
                        End With

                    Case Else
                        MsgBox("Other query")
                End Select

            Catch ex As Exception

            End Try
        End Using
        Return 0
    End Function

    Private Sub dgvSearchItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearchItems.CellClick
        If e.ColumnIndex = 0 Then
            Me.Close()
            SelectedId = dgvSearchItems.Rows(e.RowIndex).Cells(1).Value
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
                Select Case SourceForm.Name
                    Case "frmCandidateProfile"
                        Qry = <Command>
                                select 
				                    `ci_id`, `referenceid`,
				                    concat(`lastname`, ', ', `firstname`, case length(`middlename`) when 0 then '' else concat(' ' , substr(middlename,1,1) , '.') end) as fullname,
				                    case `recstatus` when 0 then 'Deleted / For Purging' else 'Active' end recstatus
			                    from rms_candidateinfo
                                where (`referenceid` like concat('%',@searchparam, '%') or
	                                    `lastname`  like concat('%',@searchparam, '%') or
	                                    `firstname` like concat('%',@searchparam, '%'))
                                  and `recstatus` = 1;
                              </Command>.Value

                        Params = New ArrayList
                        Params.Add(New MySqlParameter("@searchparam", txtSearch.Text))

                        Dset = New DataSet
                        Dset = Query(Qry, Cn, Params, CommandType.Text)

                        With dgvSearchItems
                            .DataSource = Dset.Tables(0)
                            FormatGridColumn(dgvSearchItems, 1, "", False, False, False, 50)
                            FormatGridColumn(dgvSearchItems, 2, "Reference Id", True, True, True, 150)
                            FormatGridColumn(dgvSearchItems, 3, "Candidate Name", True, True, True, 250)
                            FormatGridColumn(dgvSearchItems, 4, "Status", True, True, True, 100)
                        End With


                    Case Else
                        MsgBox("Other query")
                End Select
            End Using


        End If
    End Sub

End Class