
USE [MarketingData]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the ZohoLeads table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_Get_List

AS


				
				SELECT
					[Activities Involved],
					[Calls Involved],
					[Company],
					[CONVERTED],
					[Created By],
					[Created Time],
					[Email],
					[Email Opt Out],
					[Events Involved],
					[Features of Interest],
					[First Name],
					[First Time Caller (new lead)],
					[If No Longer Interested],
					[Industry],
					[Last Activity Time],
					[Last Name],
					[Last Visited Time],
					[Lead Owner Id],
					[Lead Owner],
					[Lead Source],
					[Lead Status],
					[LEADID],
					[Mobile],
					[Modified By],
					[Modified Time],
					[Phone],
					[Rating],
					[Secondary Email],
					[State],
					[Submission Time],
					[Submitted On],
					[Tasks Involved],
					[Time Zone],
					[URL],
					[Website],
					[Worries],
					[LEADPK],
					[WDay8-11],
					[WDay11-2],
					[WDay2-5],
					[WDay5-8],
					[Sat8-11],
					[Sat11-2],
					[Sat2-5],
					[Sat5-8],
					[Sun8-11],
					[Sun11-2],
					[Sun2-5],
					[Sun5-8]
				FROM
					[dbo].[ZohoLeads]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the ZohoLeads table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [LEADPK] bigint 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([LEADPK])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [LEADPK]'
				SET @SQL = @SQL + ' FROM [dbo].[ZohoLeads]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[Activities Involved], O.[Calls Involved], O.[Company], O.[CONVERTED], O.[Created By], O.[Created Time], O.[Email], O.[Email Opt Out], O.[Events Involved], O.[Features of Interest], O.[First Name], O.[First Time Caller (new lead)], O.[If No Longer Interested], O.[Industry], O.[Last Activity Time], O.[Last Name], O.[Last Visited Time], O.[Lead Owner Id], O.[Lead Owner], O.[Lead Source], O.[Lead Status], O.[LEADID], O.[Mobile], O.[Modified By], O.[Modified Time], O.[Phone], O.[Rating], O.[Secondary Email], O.[State], O.[Submission Time], O.[Submitted On], O.[Tasks Involved], O.[Time Zone], O.[URL], O.[Website], O.[Worries], O.[LEADPK], O.[WDay8-11], O.[WDay11-2], O.[WDay2-5], O.[WDay5-8], O.[Sat8-11], O.[Sat11-2], O.[Sat2-5], O.[Sat5-8], O.[Sun8-11], O.[Sun11-2], O.[Sun2-5], O.[Sun5-8]
				FROM
				    [dbo].[ZohoLeads] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[LEADPK] = PageIndex.[LEADPK]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ZohoLeads]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Inserts a record into the ZohoLeads table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_Insert
(

	@ActivitiesInvolved bit   ,

	@CallsInvolved bit   ,

	@Company nvarchar (255)  ,

	@Converted bit   ,

	@CreatedBy nvarchar (255)  ,

	@CreatedTime datetime   ,

	@Email nvarchar (255)  ,

	@EmailOptOut bit   ,

	@EventsInvolved bit   ,

	@FeaturesOfInterest nvarchar (255)  ,

	@FirstName nvarchar (255)  ,

	@SafeNameFirstTimeCallerNewLead bit   ,

	@IfNoLongerInterested nvarchar (255)  ,

	@Industry nvarchar (255)  ,

	@LastActivityTime datetime   ,

	@LastName nvarchar (255)  ,

	@LastVisitedTime nvarchar (255)  ,

	@LeadOwnerId nvarchar (255)  ,

	@LeadOwner nvarchar (255)  ,

	@LeadSource nvarchar (255)  ,

	@LeadStatus nvarchar (255)  ,

	@Leadid nvarchar (255)  ,

	@Mobile nvarchar (255)  ,

	@ModifiedBy nvarchar (255)  ,

	@ModifiedTime datetime   ,

	@Phone nvarchar (255)  ,

	@Rating nvarchar (255)  ,

	@SecondaryEmail nvarchar (255)  ,

	@State nvarchar (255)  ,

	@SubmissionTime nvarchar (255)  ,

	@SubmittedOn datetime   ,

	@TasksInvolved bit   ,

	@TimeZone nvarchar (255)  ,

	@Url nvarchar (255)  ,

	@Website nvarchar (255)  ,

	@Worries nvarchar (255)  ,

	@Leadpk bigint    OUTPUT,

	@Wday811 int   ,

	@Wday112 int   ,

	@Wday25 int   ,

	@Wday58 int   ,

	@Sat811 int   ,

	@Sat112 int   ,

	@Sat25 int   ,

	@Sat58 int   ,

	@Sun811 int   ,

	@Sun112 int   ,

	@Sun25 int   ,

	@Sun58 int   
)
AS


				
				INSERT INTO [dbo].[ZohoLeads]
					(
					[Activities Involved]
					,[Calls Involved]
					,[Company]
					,[CONVERTED]
					,[Created By]
					,[Created Time]
					,[Email]
					,[Email Opt Out]
					,[Events Involved]
					,[Features of Interest]
					,[First Name]
					,[First Time Caller (new lead)]
					,[If No Longer Interested]
					,[Industry]
					,[Last Activity Time]
					,[Last Name]
					,[Last Visited Time]
					,[Lead Owner Id]
					,[Lead Owner]
					,[Lead Source]
					,[Lead Status]
					,[LEADID]
					,[Mobile]
					,[Modified By]
					,[Modified Time]
					,[Phone]
					,[Rating]
					,[Secondary Email]
					,[State]
					,[Submission Time]
					,[Submitted On]
					,[Tasks Involved]
					,[Time Zone]
					,[URL]
					,[Website]
					,[Worries]
					,[WDay8-11]
					,[WDay11-2]
					,[WDay2-5]
					,[WDay5-8]
					,[Sat8-11]
					,[Sat11-2]
					,[Sat2-5]
					,[Sat5-8]
					,[Sun8-11]
					,[Sun11-2]
					,[Sun2-5]
					,[Sun5-8]
					)
				VALUES
					(
					@ActivitiesInvolved
					,@CallsInvolved
					,@Company
					,@Converted
					,@CreatedBy
					,@CreatedTime
					,@Email
					,@EmailOptOut
					,@EventsInvolved
					,@FeaturesOfInterest
					,@FirstName
					,@SafeNameFirstTimeCallerNewLead
					,@IfNoLongerInterested
					,@Industry
					,@LastActivityTime
					,@LastName
					,@LastVisitedTime
					,@LeadOwnerId
					,@LeadOwner
					,@LeadSource
					,@LeadStatus
					,@Leadid
					,@Mobile
					,@ModifiedBy
					,@ModifiedTime
					,@Phone
					,@Rating
					,@SecondaryEmail
					,@State
					,@SubmissionTime
					,@SubmittedOn
					,@TasksInvolved
					,@TimeZone
					,@Url
					,@Website
					,@Worries
					,@Wday811
					,@Wday112
					,@Wday25
					,@Wday58
					,@Sat811
					,@Sat112
					,@Sat25
					,@Sat58
					,@Sun811
					,@Sun112
					,@Sun25
					,@Sun58
					)
				-- Get the identity value
				SET @Leadpk = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Updates a record in the ZohoLeads table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_Update
(

	@ActivitiesInvolved bit   ,

	@CallsInvolved bit   ,

	@Company nvarchar (255)  ,

	@Converted bit   ,

	@CreatedBy nvarchar (255)  ,

	@CreatedTime datetime   ,

	@Email nvarchar (255)  ,

	@EmailOptOut bit   ,

	@EventsInvolved bit   ,

	@FeaturesOfInterest nvarchar (255)  ,

	@FirstName nvarchar (255)  ,

	@SafeNameFirstTimeCallerNewLead bit   ,

	@IfNoLongerInterested nvarchar (255)  ,

	@Industry nvarchar (255)  ,

	@LastActivityTime datetime   ,

	@LastName nvarchar (255)  ,

	@LastVisitedTime nvarchar (255)  ,

	@LeadOwnerId nvarchar (255)  ,

	@LeadOwner nvarchar (255)  ,

	@LeadSource nvarchar (255)  ,

	@LeadStatus nvarchar (255)  ,

	@Leadid nvarchar (255)  ,

	@Mobile nvarchar (255)  ,

	@ModifiedBy nvarchar (255)  ,

	@ModifiedTime datetime   ,

	@Phone nvarchar (255)  ,

	@Rating nvarchar (255)  ,

	@SecondaryEmail nvarchar (255)  ,

	@State nvarchar (255)  ,

	@SubmissionTime nvarchar (255)  ,

	@SubmittedOn datetime   ,

	@TasksInvolved bit   ,

	@TimeZone nvarchar (255)  ,

	@Url nvarchar (255)  ,

	@Website nvarchar (255)  ,

	@Worries nvarchar (255)  ,

	@Leadpk bigint   ,

	@Wday811 int   ,

	@Wday112 int   ,

	@Wday25 int   ,

	@Wday58 int   ,

	@Sat811 int   ,

	@Sat112 int   ,

	@Sat25 int   ,

	@Sat58 int   ,

	@Sun811 int   ,

	@Sun112 int   ,

	@Sun25 int   ,

	@Sun58 int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ZohoLeads]
				SET
					[Activities Involved] = @ActivitiesInvolved
					,[Calls Involved] = @CallsInvolved
					,[Company] = @Company
					,[CONVERTED] = @Converted
					,[Created By] = @CreatedBy
					,[Created Time] = @CreatedTime
					,[Email] = @Email
					,[Email Opt Out] = @EmailOptOut
					,[Events Involved] = @EventsInvolved
					,[Features of Interest] = @FeaturesOfInterest
					,[First Name] = @FirstName
					,[First Time Caller (new lead)] = @SafeNameFirstTimeCallerNewLead
					,[If No Longer Interested] = @IfNoLongerInterested
					,[Industry] = @Industry
					,[Last Activity Time] = @LastActivityTime
					,[Last Name] = @LastName
					,[Last Visited Time] = @LastVisitedTime
					,[Lead Owner Id] = @LeadOwnerId
					,[Lead Owner] = @LeadOwner
					,[Lead Source] = @LeadSource
					,[Lead Status] = @LeadStatus
					,[LEADID] = @Leadid
					,[Mobile] = @Mobile
					,[Modified By] = @ModifiedBy
					,[Modified Time] = @ModifiedTime
					,[Phone] = @Phone
					,[Rating] = @Rating
					,[Secondary Email] = @SecondaryEmail
					,[State] = @State
					,[Submission Time] = @SubmissionTime
					,[Submitted On] = @SubmittedOn
					,[Tasks Involved] = @TasksInvolved
					,[Time Zone] = @TimeZone
					,[URL] = @Url
					,[Website] = @Website
					,[Worries] = @Worries
					,[WDay8-11] = @Wday811
					,[WDay11-2] = @Wday112
					,[WDay2-5] = @Wday25
					,[WDay5-8] = @Wday58
					,[Sat8-11] = @Sat811
					,[Sat11-2] = @Sat112
					,[Sat2-5] = @Sat25
					,[Sat5-8] = @Sat58
					,[Sun8-11] = @Sun811
					,[Sun11-2] = @Sun112
					,[Sun2-5] = @Sun25
					,[Sun5-8] = @Sun58
				WHERE
[LEADPK] = @Leadpk 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Deletes a record in the ZohoLeads table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_Delete
(

	@Leadpk bigint   
)
AS


				DELETE FROM [dbo].[ZohoLeads] WITH (ROWLOCK) 
				WHERE
					[LEADPK] = @Leadpk
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_GetByLeadid procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_GetByLeadid') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_GetByLeadid
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Select records from the ZohoLeads table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_GetByLeadid
(

	@Leadid nvarchar (255)  
)
AS


				SELECT
					[Activities Involved],
					[Calls Involved],
					[Company],
					[CONVERTED],
					[Created By],
					[Created Time],
					[Email],
					[Email Opt Out],
					[Events Involved],
					[Features of Interest],
					[First Name],
					[First Time Caller (new lead)],
					[If No Longer Interested],
					[Industry],
					[Last Activity Time],
					[Last Name],
					[Last Visited Time],
					[Lead Owner Id],
					[Lead Owner],
					[Lead Source],
					[Lead Status],
					[LEADID],
					[Mobile],
					[Modified By],
					[Modified Time],
					[Phone],
					[Rating],
					[Secondary Email],
					[State],
					[Submission Time],
					[Submitted On],
					[Tasks Involved],
					[Time Zone],
					[URL],
					[Website],
					[Worries],
					[LEADPK],
					[WDay8-11],
					[WDay11-2],
					[WDay2-5],
					[WDay5-8],
					[Sat8-11],
					[Sat11-2],
					[Sat2-5],
					[Sat5-8],
					[Sun8-11],
					[Sun11-2],
					[Sun2-5],
					[Sun5-8]
				FROM
					[dbo].[ZohoLeads]
				WHERE
					[LEADID] = @Leadid
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_GetByLeadpk procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_GetByLeadpk') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_GetByLeadpk
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Select records from the ZohoLeads table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_GetByLeadpk
(

	@Leadpk bigint   
)
AS


				SELECT
					[Activities Involved],
					[Calls Involved],
					[Company],
					[CONVERTED],
					[Created By],
					[Created Time],
					[Email],
					[Email Opt Out],
					[Events Involved],
					[Features of Interest],
					[First Name],
					[First Time Caller (new lead)],
					[If No Longer Interested],
					[Industry],
					[Last Activity Time],
					[Last Name],
					[Last Visited Time],
					[Lead Owner Id],
					[Lead Owner],
					[Lead Source],
					[Lead Status],
					[LEADID],
					[Mobile],
					[Modified By],
					[Modified Time],
					[Phone],
					[Rating],
					[Secondary Email],
					[State],
					[Submission Time],
					[Submitted On],
					[Tasks Involved],
					[Time Zone],
					[URL],
					[Website],
					[Worries],
					[LEADPK],
					[WDay8-11],
					[WDay11-2],
					[WDay2-5],
					[WDay5-8],
					[Sat8-11],
					[Sat11-2],
					[Sat2-5],
					[Sat5-8],
					[Sun8-11],
					[Sun11-2],
					[Sun2-5],
					[Sun5-8]
				FROM
					[dbo].[ZohoLeads]
				WHERE
					[LEADPK] = @Leadpk
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoLeads_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoLeads_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoLeads_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Finds records in the ZohoLeads table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoLeads_Find
(

	@SearchUsingOR bit   = null ,

	@ActivitiesInvolved bit   = null ,

	@CallsInvolved bit   = null ,

	@Company nvarchar (255)  = null ,

	@Converted bit   = null ,

	@CreatedBy nvarchar (255)  = null ,

	@CreatedTime datetime   = null ,

	@Email nvarchar (255)  = null ,

	@EmailOptOut bit   = null ,

	@EventsInvolved bit   = null ,

	@FeaturesOfInterest nvarchar (255)  = null ,

	@FirstName nvarchar (255)  = null ,

	@SafeNameFirstTimeCallerNewLead bit   = null ,

	@IfNoLongerInterested nvarchar (255)  = null ,

	@Industry nvarchar (255)  = null ,

	@LastActivityTime datetime   = null ,

	@LastName nvarchar (255)  = null ,

	@LastVisitedTime nvarchar (255)  = null ,

	@LeadOwnerId nvarchar (255)  = null ,

	@LeadOwner nvarchar (255)  = null ,

	@LeadSource nvarchar (255)  = null ,

	@LeadStatus nvarchar (255)  = null ,

	@Leadid nvarchar (255)  = null ,

	@Mobile nvarchar (255)  = null ,

	@ModifiedBy nvarchar (255)  = null ,

	@ModifiedTime datetime   = null ,

	@Phone nvarchar (255)  = null ,

	@Rating nvarchar (255)  = null ,

	@SecondaryEmail nvarchar (255)  = null ,

	@State nvarchar (255)  = null ,

	@SubmissionTime nvarchar (255)  = null ,

	@SubmittedOn datetime   = null ,

	@TasksInvolved bit   = null ,

	@TimeZone nvarchar (255)  = null ,

	@Url nvarchar (255)  = null ,

	@Website nvarchar (255)  = null ,

	@Worries nvarchar (255)  = null ,

	@Leadpk bigint   = null ,

	@Wday811 int   = null ,

	@Wday112 int   = null ,

	@Wday25 int   = null ,

	@Wday58 int   = null ,

	@Sat811 int   = null ,

	@Sat112 int   = null ,

	@Sat25 int   = null ,

	@Sat58 int   = null ,

	@Sun811 int   = null ,

	@Sun112 int   = null ,

	@Sun25 int   = null ,

	@Sun58 int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Activities Involved]
	, [Calls Involved]
	, [Company]
	, [CONVERTED]
	, [Created By]
	, [Created Time]
	, [Email]
	, [Email Opt Out]
	, [Events Involved]
	, [Features of Interest]
	, [First Name]
	, [First Time Caller (new lead)]
	, [If No Longer Interested]
	, [Industry]
	, [Last Activity Time]
	, [Last Name]
	, [Last Visited Time]
	, [Lead Owner Id]
	, [Lead Owner]
	, [Lead Source]
	, [Lead Status]
	, [LEADID]
	, [Mobile]
	, [Modified By]
	, [Modified Time]
	, [Phone]
	, [Rating]
	, [Secondary Email]
	, [State]
	, [Submission Time]
	, [Submitted On]
	, [Tasks Involved]
	, [Time Zone]
	, [URL]
	, [Website]
	, [Worries]
	, [LEADPK]
	, [WDay8-11]
	, [WDay11-2]
	, [WDay2-5]
	, [WDay5-8]
	, [Sat8-11]
	, [Sat11-2]
	, [Sat2-5]
	, [Sat5-8]
	, [Sun8-11]
	, [Sun11-2]
	, [Sun2-5]
	, [Sun5-8]
    FROM
	[dbo].[ZohoLeads]
    WHERE 
	 ([Activities Involved] = @ActivitiesInvolved OR @ActivitiesInvolved IS NULL)
	AND ([Calls Involved] = @CallsInvolved OR @CallsInvolved IS NULL)
	AND ([Company] = @Company OR @Company IS NULL)
	AND ([CONVERTED] = @Converted OR @Converted IS NULL)
	AND ([Created By] = @CreatedBy OR @CreatedBy IS NULL)
	AND ([Created Time] = @CreatedTime OR @CreatedTime IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Email Opt Out] = @EmailOptOut OR @EmailOptOut IS NULL)
	AND ([Events Involved] = @EventsInvolved OR @EventsInvolved IS NULL)
	AND ([Features of Interest] = @FeaturesOfInterest OR @FeaturesOfInterest IS NULL)
	AND ([First Name] = @FirstName OR @FirstName IS NULL)
	AND ([First Time Caller (new lead)] = @SafeNameFirstTimeCallerNewLead OR @SafeNameFirstTimeCallerNewLead IS NULL)
	AND ([If No Longer Interested] = @IfNoLongerInterested OR @IfNoLongerInterested IS NULL)
	AND ([Industry] = @Industry OR @Industry IS NULL)
	AND ([Last Activity Time] = @LastActivityTime OR @LastActivityTime IS NULL)
	AND ([Last Name] = @LastName OR @LastName IS NULL)
	AND ([Last Visited Time] = @LastVisitedTime OR @LastVisitedTime IS NULL)
	AND ([Lead Owner Id] = @LeadOwnerId OR @LeadOwnerId IS NULL)
	AND ([Lead Owner] = @LeadOwner OR @LeadOwner IS NULL)
	AND ([Lead Source] = @LeadSource OR @LeadSource IS NULL)
	AND ([Lead Status] = @LeadStatus OR @LeadStatus IS NULL)
	AND ([LEADID] = @Leadid OR @Leadid IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([Modified By] = @ModifiedBy OR @ModifiedBy IS NULL)
	AND ([Modified Time] = @ModifiedTime OR @ModifiedTime IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Rating] = @Rating OR @Rating IS NULL)
	AND ([Secondary Email] = @SecondaryEmail OR @SecondaryEmail IS NULL)
	AND ([State] = @State OR @State IS NULL)
	AND ([Submission Time] = @SubmissionTime OR @SubmissionTime IS NULL)
	AND ([Submitted On] = @SubmittedOn OR @SubmittedOn IS NULL)
	AND ([Tasks Involved] = @TasksInvolved OR @TasksInvolved IS NULL)
	AND ([Time Zone] = @TimeZone OR @TimeZone IS NULL)
	AND ([URL] = @Url OR @Url IS NULL)
	AND ([Website] = @Website OR @Website IS NULL)
	AND ([Worries] = @Worries OR @Worries IS NULL)
	AND ([LEADPK] = @Leadpk OR @Leadpk IS NULL)
	AND ([WDay8-11] = @Wday811 OR @Wday811 IS NULL)
	AND ([WDay11-2] = @Wday112 OR @Wday112 IS NULL)
	AND ([WDay2-5] = @Wday25 OR @Wday25 IS NULL)
	AND ([WDay5-8] = @Wday58 OR @Wday58 IS NULL)
	AND ([Sat8-11] = @Sat811 OR @Sat811 IS NULL)
	AND ([Sat11-2] = @Sat112 OR @Sat112 IS NULL)
	AND ([Sat2-5] = @Sat25 OR @Sat25 IS NULL)
	AND ([Sat5-8] = @Sat58 OR @Sat58 IS NULL)
	AND ([Sun8-11] = @Sun811 OR @Sun811 IS NULL)
	AND ([Sun11-2] = @Sun112 OR @Sun112 IS NULL)
	AND ([Sun2-5] = @Sun25 OR @Sun25 IS NULL)
	AND ([Sun5-8] = @Sun58 OR @Sun58 IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Activities Involved]
	, [Calls Involved]
	, [Company]
	, [CONVERTED]
	, [Created By]
	, [Created Time]
	, [Email]
	, [Email Opt Out]
	, [Events Involved]
	, [Features of Interest]
	, [First Name]
	, [First Time Caller (new lead)]
	, [If No Longer Interested]
	, [Industry]
	, [Last Activity Time]
	, [Last Name]
	, [Last Visited Time]
	, [Lead Owner Id]
	, [Lead Owner]
	, [Lead Source]
	, [Lead Status]
	, [LEADID]
	, [Mobile]
	, [Modified By]
	, [Modified Time]
	, [Phone]
	, [Rating]
	, [Secondary Email]
	, [State]
	, [Submission Time]
	, [Submitted On]
	, [Tasks Involved]
	, [Time Zone]
	, [URL]
	, [Website]
	, [Worries]
	, [LEADPK]
	, [WDay8-11]
	, [WDay11-2]
	, [WDay2-5]
	, [WDay5-8]
	, [Sat8-11]
	, [Sat11-2]
	, [Sat2-5]
	, [Sat5-8]
	, [Sun8-11]
	, [Sun11-2]
	, [Sun2-5]
	, [Sun5-8]
    FROM
	[dbo].[ZohoLeads]
    WHERE 
	 ([Activities Involved] = @ActivitiesInvolved AND @ActivitiesInvolved is not null)
	OR ([Calls Involved] = @CallsInvolved AND @CallsInvolved is not null)
	OR ([Company] = @Company AND @Company is not null)
	OR ([CONVERTED] = @Converted AND @Converted is not null)
	OR ([Created By] = @CreatedBy AND @CreatedBy is not null)
	OR ([Created Time] = @CreatedTime AND @CreatedTime is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Email Opt Out] = @EmailOptOut AND @EmailOptOut is not null)
	OR ([Events Involved] = @EventsInvolved AND @EventsInvolved is not null)
	OR ([Features of Interest] = @FeaturesOfInterest AND @FeaturesOfInterest is not null)
	OR ([First Name] = @FirstName AND @FirstName is not null)
	OR ([First Time Caller (new lead)] = @SafeNameFirstTimeCallerNewLead AND @SafeNameFirstTimeCallerNewLead is not null)
	OR ([If No Longer Interested] = @IfNoLongerInterested AND @IfNoLongerInterested is not null)
	OR ([Industry] = @Industry AND @Industry is not null)
	OR ([Last Activity Time] = @LastActivityTime AND @LastActivityTime is not null)
	OR ([Last Name] = @LastName AND @LastName is not null)
	OR ([Last Visited Time] = @LastVisitedTime AND @LastVisitedTime is not null)
	OR ([Lead Owner Id] = @LeadOwnerId AND @LeadOwnerId is not null)
	OR ([Lead Owner] = @LeadOwner AND @LeadOwner is not null)
	OR ([Lead Source] = @LeadSource AND @LeadSource is not null)
	OR ([Lead Status] = @LeadStatus AND @LeadStatus is not null)
	OR ([LEADID] = @Leadid AND @Leadid is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([Modified By] = @ModifiedBy AND @ModifiedBy is not null)
	OR ([Modified Time] = @ModifiedTime AND @ModifiedTime is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Rating] = @Rating AND @Rating is not null)
	OR ([Secondary Email] = @SecondaryEmail AND @SecondaryEmail is not null)
	OR ([State] = @State AND @State is not null)
	OR ([Submission Time] = @SubmissionTime AND @SubmissionTime is not null)
	OR ([Submitted On] = @SubmittedOn AND @SubmittedOn is not null)
	OR ([Tasks Involved] = @TasksInvolved AND @TasksInvolved is not null)
	OR ([Time Zone] = @TimeZone AND @TimeZone is not null)
	OR ([URL] = @Url AND @Url is not null)
	OR ([Website] = @Website AND @Website is not null)
	OR ([Worries] = @Worries AND @Worries is not null)
	OR ([LEADPK] = @Leadpk AND @Leadpk is not null)
	OR ([WDay8-11] = @Wday811 AND @Wday811 is not null)
	OR ([WDay11-2] = @Wday112 AND @Wday112 is not null)
	OR ([WDay2-5] = @Wday25 AND @Wday25 is not null)
	OR ([WDay5-8] = @Wday58 AND @Wday58 is not null)
	OR ([Sat8-11] = @Sat811 AND @Sat811 is not null)
	OR ([Sat11-2] = @Sat112 AND @Sat112 is not null)
	OR ([Sat2-5] = @Sat25 AND @Sat25 is not null)
	OR ([Sat5-8] = @Sat58 AND @Sat58 is not null)
	OR ([Sun8-11] = @Sun811 AND @Sun811 is not null)
	OR ([Sun11-2] = @Sun112 AND @Sun112 is not null)
	OR ([Sun2-5] = @Sun25 AND @Sun25 is not null)
	OR ([Sun5-8] = @Sun58 AND @Sun58 is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadContacted_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadContacted_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadContacted_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the LeadContacted table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadContacted_Get_List

AS


				
				SELECT
					[LEADID],
					[USER_ID],
					[LeadContactPhone],
					[LeadContactEmail],
					[LeadContactDts],
					[LeadContactedPK],
					[ThisEventDts]
				FROM
					[dbo].[LeadContacted]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadContacted_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadContacted_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadContacted_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the LeadContacted table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadContacted_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [LeadContactedPK] bigint 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([LeadContactedPK])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [LeadContactedPK]'
				SET @SQL = @SQL + ' FROM [dbo].[LeadContacted]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[LEADID], O.[USER_ID], O.[LeadContactPhone], O.[LeadContactEmail], O.[LeadContactDts], O.[LeadContactedPK], O.[ThisEventDts]
				FROM
				    [dbo].[LeadContacted] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[LeadContactedPK] = PageIndex.[LeadContactedPK]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LeadContacted]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadContacted_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadContacted_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadContacted_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Inserts a record into the LeadContacted table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadContacted_Insert
(

	@Leadid varchar (50)  ,

	@UserId varchar (50)  ,

	@LeadContactPhone bit   ,

	@LeadContactEmail bit   ,

	@LeadContactDts nvarchar (50)  ,

	@LeadContactedPk bigint    OUTPUT,

	@ThisEventDts datetime   
)
AS


				
				INSERT INTO [dbo].[LeadContacted]
					(
					[LEADID]
					,[USER_ID]
					,[LeadContactPhone]
					,[LeadContactEmail]
					,[LeadContactDts]
					,[ThisEventDts]
					)
				VALUES
					(
					@Leadid
					,@UserId
					,@LeadContactPhone
					,@LeadContactEmail
					,@LeadContactDts
					,@ThisEventDts
					)
				-- Get the identity value
				SET @LeadContactedPk = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadContacted_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadContacted_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadContacted_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Updates a record in the LeadContacted table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadContacted_Update
(

	@Leadid varchar (50)  ,

	@UserId varchar (50)  ,

	@LeadContactPhone bit   ,

	@LeadContactEmail bit   ,

	@LeadContactDts nvarchar (50)  ,

	@LeadContactedPk bigint   ,

	@ThisEventDts datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LeadContacted]
				SET
					[LEADID] = @Leadid
					,[USER_ID] = @UserId
					,[LeadContactPhone] = @LeadContactPhone
					,[LeadContactEmail] = @LeadContactEmail
					,[LeadContactDts] = @LeadContactDts
					,[ThisEventDts] = @ThisEventDts
				WHERE
[LeadContactedPK] = @LeadContactedPk 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadContacted_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadContacted_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadContacted_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Deletes a record in the LeadContacted table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadContacted_Delete
(

	@LeadContactedPk bigint   
)
AS


				DELETE FROM [dbo].[LeadContacted] WITH (ROWLOCK) 
				WHERE
					[LeadContactedPK] = @LeadContactedPk
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadContacted_GetByLeadContactedPk procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadContacted_GetByLeadContactedPk') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadContacted_GetByLeadContactedPk
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Select records from the LeadContacted table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadContacted_GetByLeadContactedPk
(

	@LeadContactedPk bigint   
)
AS


				SELECT
					[LEADID],
					[USER_ID],
					[LeadContactPhone],
					[LeadContactEmail],
					[LeadContactDts],
					[LeadContactedPK],
					[ThisEventDts]
				FROM
					[dbo].[LeadContacted]
				WHERE
					[LeadContactedPK] = @LeadContactedPk
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadContacted_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadContacted_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadContacted_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Finds records in the LeadContacted table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadContacted_Find
(

	@SearchUsingOR bit   = null ,

	@Leadid varchar (50)  = null ,

	@UserId varchar (50)  = null ,

	@LeadContactPhone bit   = null ,

	@LeadContactEmail bit   = null ,

	@LeadContactDts nvarchar (50)  = null ,

	@LeadContactedPk bigint   = null ,

	@ThisEventDts datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [LEADID]
	, [USER_ID]
	, [LeadContactPhone]
	, [LeadContactEmail]
	, [LeadContactDts]
	, [LeadContactedPK]
	, [ThisEventDts]
    FROM
	[dbo].[LeadContacted]
    WHERE 
	 ([LEADID] = @Leadid OR @Leadid IS NULL)
	AND ([USER_ID] = @UserId OR @UserId IS NULL)
	AND ([LeadContactPhone] = @LeadContactPhone OR @LeadContactPhone IS NULL)
	AND ([LeadContactEmail] = @LeadContactEmail OR @LeadContactEmail IS NULL)
	AND ([LeadContactDts] = @LeadContactDts OR @LeadContactDts IS NULL)
	AND ([LeadContactedPK] = @LeadContactedPk OR @LeadContactedPk IS NULL)
	AND ([ThisEventDts] = @ThisEventDts OR @ThisEventDts IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [LEADID]
	, [USER_ID]
	, [LeadContactPhone]
	, [LeadContactEmail]
	, [LeadContactDts]
	, [LeadContactedPK]
	, [ThisEventDts]
    FROM
	[dbo].[LeadContacted]
    WHERE 
	 ([LEADID] = @Leadid AND @Leadid is not null)
	OR ([USER_ID] = @UserId AND @UserId is not null)
	OR ([LeadContactPhone] = @LeadContactPhone AND @LeadContactPhone is not null)
	OR ([LeadContactEmail] = @LeadContactEmail AND @LeadContactEmail is not null)
	OR ([LeadContactDts] = @LeadContactDts AND @LeadContactDts is not null)
	OR ([LeadContactedPK] = @LeadContactedPk AND @LeadContactedPk is not null)
	OR ([ThisEventDts] = @ThisEventDts AND @ThisEventDts is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the ZohoCalls table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_Get_List

AS


				
				SELECT
					[ACCOUNTID],
					[Billable],
					[Call Duration],
					[Call Duration (in minutes)],
					[Call Duration (in seconds)],
					[Call Owner],
					[Call Owner Id],
					[Call Purpose],
					[Call Result],
					[Call Start Time],
					[Call Type],
					[ContactID],
					[CreatedBy],
					[Created Time],
					[LEADID],
					[Modified Time],
					[POTENTIALID],
					[RELATED To],
					[SEMODULE],
					[Subject],
					[TASKID],
					[Who Id Id],
					[CallPK]
				FROM
					[dbo].[ZohoCalls]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the ZohoCalls table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [CallPK] bigint 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([CallPK])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [CallPK]'
				SET @SQL = @SQL + ' FROM [dbo].[ZohoCalls]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ACCOUNTID], O.[Billable], O.[Call Duration], O.[Call Duration (in minutes)], O.[Call Duration (in seconds)], O.[Call Owner], O.[Call Owner Id], O.[Call Purpose], O.[Call Result], O.[Call Start Time], O.[Call Type], O.[ContactID], O.[CreatedBy], O.[Created Time], O.[LEADID], O.[Modified Time], O.[POTENTIALID], O.[RELATED To], O.[SEMODULE], O.[Subject], O.[TASKID], O.[Who Id Id], O.[CallPK]
				FROM
				    [dbo].[ZohoCalls] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[CallPK] = PageIndex.[CallPK]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ZohoCalls]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Inserts a record into the ZohoCalls table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_Insert
(

	@Accountid nvarchar (255)  ,

	@Billable nvarchar (255)  ,

	@CallDuration nvarchar (255)  ,

	@SafeNameCallDurationInMinutes float   ,

	@SafeNameCallDurationInSeconds float   ,

	@CallOwner nvarchar (255)  ,

	@CallOwnerId nvarchar (255)  ,

	@CallPurpose nvarchar (255)  ,

	@CallResult nvarchar (255)  ,

	@CallStartTime datetime   ,

	@CallType nvarchar (255)  ,

	@ContactId nvarchar (255)  ,

	@CreatedBy nvarchar (255)  ,

	@CreatedTime datetime   ,

	@Leadid nvarchar (255)  ,

	@ModifiedTime datetime   ,

	@Potentialid nvarchar (255)  ,

	@RelatedTo nvarchar (255)  ,

	@Semodule nvarchar (255)  ,

	@Subject nvarchar (255)  ,

	@Taskid nvarchar (255)  ,

	@WhoIdId nvarchar (255)  ,

	@CallPk bigint    OUTPUT
)
AS


				
				INSERT INTO [dbo].[ZohoCalls]
					(
					[ACCOUNTID]
					,[Billable]
					,[Call Duration]
					,[Call Duration (in minutes)]
					,[Call Duration (in seconds)]
					,[Call Owner]
					,[Call Owner Id]
					,[Call Purpose]
					,[Call Result]
					,[Call Start Time]
					,[Call Type]
					,[ContactID]
					,[CreatedBy]
					,[Created Time]
					,[LEADID]
					,[Modified Time]
					,[POTENTIALID]
					,[RELATED To]
					,[SEMODULE]
					,[Subject]
					,[TASKID]
					,[Who Id Id]
					)
				VALUES
					(
					@Accountid
					,@Billable
					,@CallDuration
					,@SafeNameCallDurationInMinutes
					,@SafeNameCallDurationInSeconds
					,@CallOwner
					,@CallOwnerId
					,@CallPurpose
					,@CallResult
					,@CallStartTime
					,@CallType
					,@ContactId
					,@CreatedBy
					,@CreatedTime
					,@Leadid
					,@ModifiedTime
					,@Potentialid
					,@RelatedTo
					,@Semodule
					,@Subject
					,@Taskid
					,@WhoIdId
					)
				-- Get the identity value
				SET @CallPk = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Updates a record in the ZohoCalls table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_Update
(

	@Accountid nvarchar (255)  ,

	@Billable nvarchar (255)  ,

	@CallDuration nvarchar (255)  ,

	@SafeNameCallDurationInMinutes float   ,

	@SafeNameCallDurationInSeconds float   ,

	@CallOwner nvarchar (255)  ,

	@CallOwnerId nvarchar (255)  ,

	@CallPurpose nvarchar (255)  ,

	@CallResult nvarchar (255)  ,

	@CallStartTime datetime   ,

	@CallType nvarchar (255)  ,

	@ContactId nvarchar (255)  ,

	@CreatedBy nvarchar (255)  ,

	@CreatedTime datetime   ,

	@Leadid nvarchar (255)  ,

	@ModifiedTime datetime   ,

	@Potentialid nvarchar (255)  ,

	@RelatedTo nvarchar (255)  ,

	@Semodule nvarchar (255)  ,

	@Subject nvarchar (255)  ,

	@Taskid nvarchar (255)  ,

	@WhoIdId nvarchar (255)  ,

	@CallPk bigint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ZohoCalls]
				SET
					[ACCOUNTID] = @Accountid
					,[Billable] = @Billable
					,[Call Duration] = @CallDuration
					,[Call Duration (in minutes)] = @SafeNameCallDurationInMinutes
					,[Call Duration (in seconds)] = @SafeNameCallDurationInSeconds
					,[Call Owner] = @CallOwner
					,[Call Owner Id] = @CallOwnerId
					,[Call Purpose] = @CallPurpose
					,[Call Result] = @CallResult
					,[Call Start Time] = @CallStartTime
					,[Call Type] = @CallType
					,[ContactID] = @ContactId
					,[CreatedBy] = @CreatedBy
					,[Created Time] = @CreatedTime
					,[LEADID] = @Leadid
					,[Modified Time] = @ModifiedTime
					,[POTENTIALID] = @Potentialid
					,[RELATED To] = @RelatedTo
					,[SEMODULE] = @Semodule
					,[Subject] = @Subject
					,[TASKID] = @Taskid
					,[Who Id Id] = @WhoIdId
				WHERE
[CallPK] = @CallPk 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Deletes a record in the ZohoCalls table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_Delete
(

	@CallPk bigint   
)
AS


				DELETE FROM [dbo].[ZohoCalls] WITH (ROWLOCK) 
				WHERE
					[CallPK] = @CallPk
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_GetByCallPk procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_GetByCallPk') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_GetByCallPk
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Select records from the ZohoCalls table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_GetByCallPk
(

	@CallPk bigint   
)
AS


				SELECT
					[ACCOUNTID],
					[Billable],
					[Call Duration],
					[Call Duration (in minutes)],
					[Call Duration (in seconds)],
					[Call Owner],
					[Call Owner Id],
					[Call Purpose],
					[Call Result],
					[Call Start Time],
					[Call Type],
					[ContactID],
					[CreatedBy],
					[Created Time],
					[LEADID],
					[Modified Time],
					[POTENTIALID],
					[RELATED To],
					[SEMODULE],
					[Subject],
					[TASKID],
					[Who Id Id],
					[CallPK]
				FROM
					[dbo].[ZohoCalls]
				WHERE
					[CallPK] = @CallPk
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_GetByLeadid procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_GetByLeadid') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_GetByLeadid
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Select records from the ZohoCalls table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_GetByLeadid
(

	@Leadid nvarchar (255)  
)
AS


				SELECT
					[ACCOUNTID],
					[Billable],
					[Call Duration],
					[Call Duration (in minutes)],
					[Call Duration (in seconds)],
					[Call Owner],
					[Call Owner Id],
					[Call Purpose],
					[Call Result],
					[Call Start Time],
					[Call Type],
					[ContactID],
					[CreatedBy],
					[Created Time],
					[LEADID],
					[Modified Time],
					[POTENTIALID],
					[RELATED To],
					[SEMODULE],
					[Subject],
					[TASKID],
					[Who Id Id],
					[CallPK]
				FROM
					[dbo].[ZohoCalls]
				WHERE
					[LEADID] = @Leadid
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoCalls_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoCalls_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoCalls_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Finds records in the ZohoCalls table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoCalls_Find
(

	@SearchUsingOR bit   = null ,

	@Accountid nvarchar (255)  = null ,

	@Billable nvarchar (255)  = null ,

	@CallDuration nvarchar (255)  = null ,

	@SafeNameCallDurationInMinutes float   = null ,

	@SafeNameCallDurationInSeconds float   = null ,

	@CallOwner nvarchar (255)  = null ,

	@CallOwnerId nvarchar (255)  = null ,

	@CallPurpose nvarchar (255)  = null ,

	@CallResult nvarchar (255)  = null ,

	@CallStartTime datetime   = null ,

	@CallType nvarchar (255)  = null ,

	@ContactId nvarchar (255)  = null ,

	@CreatedBy nvarchar (255)  = null ,

	@CreatedTime datetime   = null ,

	@Leadid nvarchar (255)  = null ,

	@ModifiedTime datetime   = null ,

	@Potentialid nvarchar (255)  = null ,

	@RelatedTo nvarchar (255)  = null ,

	@Semodule nvarchar (255)  = null ,

	@Subject nvarchar (255)  = null ,

	@Taskid nvarchar (255)  = null ,

	@WhoIdId nvarchar (255)  = null ,

	@CallPk bigint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ACCOUNTID]
	, [Billable]
	, [Call Duration]
	, [Call Duration (in minutes)]
	, [Call Duration (in seconds)]
	, [Call Owner]
	, [Call Owner Id]
	, [Call Purpose]
	, [Call Result]
	, [Call Start Time]
	, [Call Type]
	, [ContactID]
	, [CreatedBy]
	, [Created Time]
	, [LEADID]
	, [Modified Time]
	, [POTENTIALID]
	, [RELATED To]
	, [SEMODULE]
	, [Subject]
	, [TASKID]
	, [Who Id Id]
	, [CallPK]
    FROM
	[dbo].[ZohoCalls]
    WHERE 
	 ([ACCOUNTID] = @Accountid OR @Accountid IS NULL)
	AND ([Billable] = @Billable OR @Billable IS NULL)
	AND ([Call Duration] = @CallDuration OR @CallDuration IS NULL)
	AND ([Call Duration (in minutes)] = @SafeNameCallDurationInMinutes OR @SafeNameCallDurationInMinutes IS NULL)
	AND ([Call Duration (in seconds)] = @SafeNameCallDurationInSeconds OR @SafeNameCallDurationInSeconds IS NULL)
	AND ([Call Owner] = @CallOwner OR @CallOwner IS NULL)
	AND ([Call Owner Id] = @CallOwnerId OR @CallOwnerId IS NULL)
	AND ([Call Purpose] = @CallPurpose OR @CallPurpose IS NULL)
	AND ([Call Result] = @CallResult OR @CallResult IS NULL)
	AND ([Call Start Time] = @CallStartTime OR @CallStartTime IS NULL)
	AND ([Call Type] = @CallType OR @CallType IS NULL)
	AND ([ContactID] = @ContactId OR @ContactId IS NULL)
	AND ([CreatedBy] = @CreatedBy OR @CreatedBy IS NULL)
	AND ([Created Time] = @CreatedTime OR @CreatedTime IS NULL)
	AND ([LEADID] = @Leadid OR @Leadid IS NULL)
	AND ([Modified Time] = @ModifiedTime OR @ModifiedTime IS NULL)
	AND ([POTENTIALID] = @Potentialid OR @Potentialid IS NULL)
	AND ([RELATED To] = @RelatedTo OR @RelatedTo IS NULL)
	AND ([SEMODULE] = @Semodule OR @Semodule IS NULL)
	AND ([Subject] = @Subject OR @Subject IS NULL)
	AND ([TASKID] = @Taskid OR @Taskid IS NULL)
	AND ([Who Id Id] = @WhoIdId OR @WhoIdId IS NULL)
	AND ([CallPK] = @CallPk OR @CallPk IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ACCOUNTID]
	, [Billable]
	, [Call Duration]
	, [Call Duration (in minutes)]
	, [Call Duration (in seconds)]
	, [Call Owner]
	, [Call Owner Id]
	, [Call Purpose]
	, [Call Result]
	, [Call Start Time]
	, [Call Type]
	, [ContactID]
	, [CreatedBy]
	, [Created Time]
	, [LEADID]
	, [Modified Time]
	, [POTENTIALID]
	, [RELATED To]
	, [SEMODULE]
	, [Subject]
	, [TASKID]
	, [Who Id Id]
	, [CallPK]
    FROM
	[dbo].[ZohoCalls]
    WHERE 
	 ([ACCOUNTID] = @Accountid AND @Accountid is not null)
	OR ([Billable] = @Billable AND @Billable is not null)
	OR ([Call Duration] = @CallDuration AND @CallDuration is not null)
	OR ([Call Duration (in minutes)] = @SafeNameCallDurationInMinutes AND @SafeNameCallDurationInMinutes is not null)
	OR ([Call Duration (in seconds)] = @SafeNameCallDurationInSeconds AND @SafeNameCallDurationInSeconds is not null)
	OR ([Call Owner] = @CallOwner AND @CallOwner is not null)
	OR ([Call Owner Id] = @CallOwnerId AND @CallOwnerId is not null)
	OR ([Call Purpose] = @CallPurpose AND @CallPurpose is not null)
	OR ([Call Result] = @CallResult AND @CallResult is not null)
	OR ([Call Start Time] = @CallStartTime AND @CallStartTime is not null)
	OR ([Call Type] = @CallType AND @CallType is not null)
	OR ([ContactID] = @ContactId AND @ContactId is not null)
	OR ([CreatedBy] = @CreatedBy AND @CreatedBy is not null)
	OR ([Created Time] = @CreatedTime AND @CreatedTime is not null)
	OR ([LEADID] = @Leadid AND @Leadid is not null)
	OR ([Modified Time] = @ModifiedTime AND @ModifiedTime is not null)
	OR ([POTENTIALID] = @Potentialid AND @Potentialid is not null)
	OR ([RELATED To] = @RelatedTo AND @RelatedTo is not null)
	OR ([SEMODULE] = @Semodule AND @Semodule is not null)
	OR ([Subject] = @Subject AND @Subject is not null)
	OR ([TASKID] = @Taskid AND @Taskid is not null)
	OR ([Who Id Id] = @WhoIdId AND @WhoIdId is not null)
	OR ([CallPK] = @CallPk AND @CallPk is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoUsers_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoUsers_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoUsers_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the ZohoUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoUsers_Get_List

AS


				
				SELECT
					[USER_ID],
					[First Name],
					[Last Name],
					[Email],
					[USERPK]
				FROM
					[dbo].[ZohoUsers]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoUsers_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoUsers_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoUsers_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the ZohoUsers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoUsers_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [USERPK] bigint 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([USERPK])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [USERPK]'
				SET @SQL = @SQL + ' FROM [dbo].[ZohoUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[USER_ID], O.[First Name], O.[Last Name], O.[Email], O.[USERPK]
				FROM
				    [dbo].[ZohoUsers] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[USERPK] = PageIndex.[USERPK]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ZohoUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoUsers_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoUsers_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoUsers_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Inserts a record into the ZohoUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoUsers_Insert
(

	@UserId varchar (50)  ,

	@FirstName varchar (50)  ,

	@LastName varchar (50)  ,

	@Email varchar (50)  ,

	@Userpk bigint    OUTPUT
)
AS


				
				INSERT INTO [dbo].[ZohoUsers]
					(
					[USER_ID]
					,[First Name]
					,[Last Name]
					,[Email]
					)
				VALUES
					(
					@UserId
					,@FirstName
					,@LastName
					,@Email
					)
				-- Get the identity value
				SET @Userpk = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoUsers_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoUsers_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoUsers_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Updates a record in the ZohoUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoUsers_Update
(

	@UserId varchar (50)  ,

	@FirstName varchar (50)  ,

	@LastName varchar (50)  ,

	@Email varchar (50)  ,

	@Userpk bigint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ZohoUsers]
				SET
					[USER_ID] = @UserId
					,[First Name] = @FirstName
					,[Last Name] = @LastName
					,[Email] = @Email
				WHERE
[USERPK] = @Userpk 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoUsers_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoUsers_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoUsers_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Deletes a record in the ZohoUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoUsers_Delete
(

	@Userpk bigint   
)
AS


				DELETE FROM [dbo].[ZohoUsers] WITH (ROWLOCK) 
				WHERE
					[USERPK] = @Userpk
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoUsers_GetByUserpk procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoUsers_GetByUserpk') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoUsers_GetByUserpk
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Select records from the ZohoUsers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoUsers_GetByUserpk
(

	@Userpk bigint   
)
AS


				SELECT
					[USER_ID],
					[First Name],
					[Last Name],
					[Email],
					[USERPK]
				FROM
					[dbo].[ZohoUsers]
				WHERE
					[USERPK] = @Userpk
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZohoUsers_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZohoUsers_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZohoUsers_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Finds records in the ZohoUsers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZohoUsers_Find
(

	@SearchUsingOR bit   = null ,

	@UserId varchar (50)  = null ,

	@FirstName varchar (50)  = null ,

	@LastName varchar (50)  = null ,

	@Email varchar (50)  = null ,

	@Userpk bigint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [USER_ID]
	, [First Name]
	, [Last Name]
	, [Email]
	, [USERPK]
    FROM
	[dbo].[ZohoUsers]
    WHERE 
	 ([USER_ID] = @UserId OR @UserId IS NULL)
	AND ([First Name] = @FirstName OR @FirstName IS NULL)
	AND ([Last Name] = @LastName OR @LastName IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([USERPK] = @Userpk OR @Userpk IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [USER_ID]
	, [First Name]
	, [Last Name]
	, [Email]
	, [USERPK]
    FROM
	[dbo].[ZohoUsers]
    WHERE 
	 ([USER_ID] = @UserId AND @UserId is not null)
	OR ([First Name] = @FirstName AND @FirstName is not null)
	OR ([Last Name] = @LastName AND @LastName is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([USERPK] = @Userpk AND @Userpk is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadHoldAndCall_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadHoldAndCall_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadHoldAndCall_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the LeadHoldAndCall table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadHoldAndCall_Get_List

AS


				
				SELECT
					[LEADID],
					[USER_ID],
					[LeadHoldDts],
					[LeadCalled],
					[LeadDefered],
					[LeadActionDts],
					[LeadHoldAndCallPK]
				FROM
					[dbo].[LeadHoldAndCall]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadHoldAndCall_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadHoldAndCall_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadHoldAndCall_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the LeadHoldAndCall table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadHoldAndCall_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [LeadHoldAndCallPK] bigint 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([LeadHoldAndCallPK])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [LeadHoldAndCallPK]'
				SET @SQL = @SQL + ' FROM [dbo].[LeadHoldAndCall]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[LEADID], O.[USER_ID], O.[LeadHoldDts], O.[LeadCalled], O.[LeadDefered], O.[LeadActionDts], O.[LeadHoldAndCallPK]
				FROM
				    [dbo].[LeadHoldAndCall] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[LeadHoldAndCallPK] = PageIndex.[LeadHoldAndCallPK]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LeadHoldAndCall]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadHoldAndCall_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadHoldAndCall_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadHoldAndCall_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Inserts a record into the LeadHoldAndCall table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadHoldAndCall_Insert
(

	@Leadid varchar (50)  ,

	@UserId varchar (50)  ,

	@LeadHoldDts datetime   ,

	@LeadCalled bit   ,

	@LeadDefered bit   ,

	@LeadActionDts datetime   ,

	@LeadHoldAndCallPk bigint    OUTPUT
)
AS


				
				INSERT INTO [dbo].[LeadHoldAndCall]
					(
					[LEADID]
					,[USER_ID]
					,[LeadHoldDts]
					,[LeadCalled]
					,[LeadDefered]
					,[LeadActionDts]
					)
				VALUES
					(
					@Leadid
					,@UserId
					,@LeadHoldDts
					,@LeadCalled
					,@LeadDefered
					,@LeadActionDts
					)
				-- Get the identity value
				SET @LeadHoldAndCallPk = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadHoldAndCall_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadHoldAndCall_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadHoldAndCall_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Updates a record in the LeadHoldAndCall table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadHoldAndCall_Update
(

	@Leadid varchar (50)  ,

	@UserId varchar (50)  ,

	@LeadHoldDts datetime   ,

	@LeadCalled bit   ,

	@LeadDefered bit   ,

	@LeadActionDts datetime   ,

	@LeadHoldAndCallPk bigint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LeadHoldAndCall]
				SET
					[LEADID] = @Leadid
					,[USER_ID] = @UserId
					,[LeadHoldDts] = @LeadHoldDts
					,[LeadCalled] = @LeadCalled
					,[LeadDefered] = @LeadDefered
					,[LeadActionDts] = @LeadActionDts
				WHERE
[LeadHoldAndCallPK] = @LeadHoldAndCallPk 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadHoldAndCall_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadHoldAndCall_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadHoldAndCall_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Deletes a record in the LeadHoldAndCall table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadHoldAndCall_Delete
(

	@LeadHoldAndCallPk bigint   
)
AS


				DELETE FROM [dbo].[LeadHoldAndCall] WITH (ROWLOCK) 
				WHERE
					[LeadHoldAndCallPK] = @LeadHoldAndCallPk
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadHoldAndCall_GetByLeadHoldAndCallPk procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadHoldAndCall_GetByLeadHoldAndCallPk') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadHoldAndCall_GetByLeadHoldAndCallPk
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Select records from the LeadHoldAndCall table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadHoldAndCall_GetByLeadHoldAndCallPk
(

	@LeadHoldAndCallPk bigint   
)
AS


				SELECT
					[LEADID],
					[USER_ID],
					[LeadHoldDts],
					[LeadCalled],
					[LeadDefered],
					[LeadActionDts],
					[LeadHoldAndCallPK]
				FROM
					[dbo].[LeadHoldAndCall]
				WHERE
					[LeadHoldAndCallPK] = @LeadHoldAndCallPk
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LeadHoldAndCall_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LeadHoldAndCall_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LeadHoldAndCall_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Finds records in the LeadHoldAndCall table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LeadHoldAndCall_Find
(

	@SearchUsingOR bit   = null ,

	@Leadid varchar (50)  = null ,

	@UserId varchar (50)  = null ,

	@LeadHoldDts datetime   = null ,

	@LeadCalled bit   = null ,

	@LeadDefered bit   = null ,

	@LeadActionDts datetime   = null ,

	@LeadHoldAndCallPk bigint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [LEADID]
	, [USER_ID]
	, [LeadHoldDts]
	, [LeadCalled]
	, [LeadDefered]
	, [LeadActionDts]
	, [LeadHoldAndCallPK]
    FROM
	[dbo].[LeadHoldAndCall]
    WHERE 
	 ([LEADID] = @Leadid OR @Leadid IS NULL)
	AND ([USER_ID] = @UserId OR @UserId IS NULL)
	AND ([LeadHoldDts] = @LeadHoldDts OR @LeadHoldDts IS NULL)
	AND ([LeadCalled] = @LeadCalled OR @LeadCalled IS NULL)
	AND ([LeadDefered] = @LeadDefered OR @LeadDefered IS NULL)
	AND ([LeadActionDts] = @LeadActionDts OR @LeadActionDts IS NULL)
	AND ([LeadHoldAndCallPK] = @LeadHoldAndCallPk OR @LeadHoldAndCallPk IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [LEADID]
	, [USER_ID]
	, [LeadHoldDts]
	, [LeadCalled]
	, [LeadDefered]
	, [LeadActionDts]
	, [LeadHoldAndCallPK]
    FROM
	[dbo].[LeadHoldAndCall]
    WHERE 
	 ([LEADID] = @Leadid AND @Leadid is not null)
	OR ([USER_ID] = @UserId AND @UserId is not null)
	OR ([LeadHoldDts] = @LeadHoldDts AND @LeadHoldDts is not null)
	OR ([LeadCalled] = @LeadCalled AND @LeadCalled is not null)
	OR ([LeadDefered] = @LeadDefered AND @LeadDefered is not null)
	OR ([LeadActionDts] = @LeadActionDts AND @LeadActionDts is not null)
	OR ([LeadHoldAndCallPK] = @LeadHoldAndCallPk AND @LeadHoldAndCallPk is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_AllLeadsWithCallsAndPeriods_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_AllLeadsWithCallsAndPeriods_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_AllLeadsWithCallsAndPeriods_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_AllLeadsWithCallsAndPeriods view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_AllLeadsWithCallsAndPeriods_Get_List

AS


                    
                    SELECT
                        [Lead Status],
                        [LEADID],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Lead Owner],
                        [Rating],
                        [State],
                        [Time Zone],
                        [SatMC],
                        [SatDC],
                        [SatAC],
                        [SatEC],
                        [SunMC],
                        [SunDC],
                        [SunAC],
                        [SunEC],
                        [DMC],
                        [DDC],
                        [DAC],
                        [DEC],
                        [Phone]
                    FROM
                        [dbo].[vw_AllLeadsWithCallsAndPeriods]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_AllLeadsWithCallsAndPeriods_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_AllLeadsWithCallsAndPeriods_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_AllLeadsWithCallsAndPeriods_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_AllLeadsWithCallsAndPeriods view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_AllLeadsWithCallsAndPeriods_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_AllLeadsWithCallsAndPeriods]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadContactInFuture_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadContactInFuture_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadContactInFuture_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_BaseLeadContactInFuture view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadContactInFuture_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id],
                        [total calls]
                    FROM
                        [dbo].[vw_BaseLeadContactInFuture]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadContactInFuture_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadContactInFuture_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadContactInFuture_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_BaseLeadContactInFuture view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadContactInFuture_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_BaseLeadContactInFuture]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_BaseLeadGetLessThanThreeCallsInPeriod view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id],
                        [total calls]
                    FROM
                        [dbo].[vw_BaseLeadGetLessThanThreeCallsInPeriod]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_BaseLeadGetLessThanThreeCallsInPeriod view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetLessThanThreeCallsInPeriod_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_BaseLeadGetLessThanThreeCallsInPeriod]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_BaseLeadGetLessThanTwoCallsInPeriod view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id],
                        [total calls]
                    FROM
                        [dbo].[vw_BaseLeadGetLessThanTwoCallsInPeriod]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_BaseLeadGetLessThanTwoCallsInPeriod view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetLessThanTwoCallsInPeriod_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_BaseLeadGetLessThanTwoCallsInPeriod]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_BaseLeadGetWithNoActivityIn60Days view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id],
                        [total calls]
                    FROM
                        [dbo].[vw_BaseLeadGetWithNoActivityIn60Days]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_BaseLeadGetWithNoActivityIn60Days view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetWithNoActivityIn60Days_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_BaseLeadGetWithNoActivityIn60Days]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetWithNoActivityInNDays_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetWithNoActivityInNDays_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetWithNoActivityInNDays_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_BaseLeadGetWithNoActivityInNDays view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetWithNoActivityInNDays_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id],
                        [total calls]
                    FROM
                        [dbo].[vw_BaseLeadGetWithNoActivityInNDays]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetWithNoActivityInNDays_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetWithNoActivityInNDays_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetWithNoActivityInNDays_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_BaseLeadGetWithNoActivityInNDays view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetWithNoActivityInNDays_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_BaseLeadGetWithNoActivityInNDays]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetZeroCallsInPeriod_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetZeroCallsInPeriod_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetZeroCallsInPeriod_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_BaseLeadGetZeroCallsInPeriod view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetZeroCallsInPeriod_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id],
                        [total calls]
                    FROM
                        [dbo].[vw_BaseLeadGetZeroCallsInPeriod]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_BaseLeadGetZeroCallsInPeriod_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_BaseLeadGetZeroCallsInPeriod_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_BaseLeadGetZeroCallsInPeriod_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_BaseLeadGetZeroCallsInPeriod view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_BaseLeadGetZeroCallsInPeriod_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_BaseLeadGetZeroCallsInPeriod]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLeadsWithCalls_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLeadsWithCalls_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLeadsWithCalls_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_CallableLeadsWithCalls view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLeadsWithCalls_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [First Name],
                        [Last Name],
                        [Phone],
                        [Call Start Time],
                        [HOUR],
                        [DAYTYPE],
                        [Time Zone],
                        [Created Time],
                        [DayOfWeek],
                        [Rating]
                    FROM
                        [dbo].[vw_CallableLeadsWithCalls]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLeadsWithCalls_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLeadsWithCalls_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLeadsWithCalls_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_CallableLeadsWithCalls view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLeadsWithCalls_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_CallableLeadsWithCalls]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLEadsWithCallsAndHourAdj_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLEadsWithCallsAndHourAdj_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLEadsWithCallsAndHourAdj_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_CallableLEadsWithCallsAndHourAdj view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLEadsWithCallsAndHourAdj_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [First Name],
                        [Last Name],
                        [Phone],
                        [Call Start Time],
                        [HOUR],
                        [DAYTYPE],
                        [Time Zone],
                        [HOUR_ADJ],
                        [Created Time],
                        [DayOfWeek]
                    FROM
                        [dbo].[vw_CallableLEadsWithCallsAndHourAdj]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLEadsWithCallsAndHourAdj_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLEadsWithCallsAndHourAdj_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLEadsWithCallsAndHourAdj_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_CallableLEadsWithCallsAndHourAdj view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLEadsWithCallsAndHourAdj_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_CallableLEadsWithCallsAndHourAdj]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLeadsWithCallsAndPeriod_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLeadsWithCallsAndPeriod_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriod_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_CallableLeadsWithCallsAndPeriod view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriod_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [First Name],
                        [Last Name],
                        [Phone],
                        [Call Start Time],
                        [HOUR],
                        [DAYTYPE],
                        [Time Zone],
                        [HOUR_ADJ],
                        [PERIOD],
                        [Created Time]
                    FROM
                        [dbo].[vw_CallableLeadsWithCallsAndPeriod]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLeadsWithCallsAndPeriod_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLeadsWithCallsAndPeriod_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriod_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_CallableLeadsWithCallsAndPeriod view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriod_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_CallableLeadsWithCallsAndPeriod]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLeadsWithCallsAndPeriods_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLeadsWithCallsAndPeriods_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriods_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_CallableLeadsWithCallsAndPeriods view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriods_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Lead Owner],
                        [Rating],
                        [State],
                        [Time Zone],
                        [SatMC],
                        [SatDC],
                        [SatAC],
                        [SatEC],
                        [SunMC],
                        [SunDC],
                        [SunAC],
                        [SunEC],
                        [DMC],
                        [DDC],
                        [DAC],
                        [DEC],
                        [Phone]
                    FROM
                        [dbo].[vw_CallableLeadsWithCallsAndPeriods]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallableLeadsWithCallsAndPeriods_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallableLeadsWithCallsAndPeriods_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriods_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_CallableLeadsWithCallsAndPeriods view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallableLeadsWithCallsAndPeriods_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_CallableLeadsWithCallsAndPeriods]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallsByUser_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallsByUser_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallsByUser_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_CallsByUser view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallsByUser_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [Call Duration (in seconds)],
                        [Call Purpose],
                        [Call Result],
                        [Call Type],
                        [Call Start Time],
                        [USER_ID],
                        [First Name],
                        [Last Name],
                        [Call Owner],
                        [Call Owner Id]
                    FROM
                        [dbo].[vw_CallsByUser]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_CallsByUser_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_CallsByUser_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_CallsByUser_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_CallsByUser view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_CallsByUser_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_CallsByUser]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_DeferedLeads_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_DeferedLeads_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_DeferedLeads_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_DeferedLeads view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_DeferedLeads_Get_List

AS


                    
                    SELECT
                        [LEADID]
                    FROM
                        [dbo].[vw_DeferedLeads]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_DeferedLeads_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_DeferedLeads_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_DeferedLeads_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_DeferedLeads view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_DeferedLeads_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_DeferedLeads]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_HoldAndCallWithLeadInfo_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_HoldAndCallWithLeadInfo_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_HoldAndCallWithLeadInfo_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_HoldAndCallWithLeadInfo view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_HoldAndCallWithLeadInfo_Get_List

AS


                    
                    SELECT
                        [First Name],
                        [Last Name],
                        [Lead Status],
                        [Rating],
                        [Lead Owner],
                        [LeadHoldDts],
                        [LeadCalled],
                        [LeadDefered],
                        [LeadActionDts],
                        [LEADID],
                        [USER_ID]
                    FROM
                        [dbo].[vw_HoldAndCallWithLeadInfo]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_HoldAndCallWithLeadInfo_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_HoldAndCallWithLeadInfo_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_HoldAndCallWithLeadInfo_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_HoldAndCallWithLeadInfo view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_HoldAndCallWithLeadInfo_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_HoldAndCallWithLeadInfo]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LastCallCreated_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LastCallCreated_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LastCallCreated_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LastCallCreated view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LastCallCreated_Get_List

AS


                    
                    SELECT
                        [last call created]
                    FROM
                        [dbo].[vw_LastCallCreated]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LastCallCreated_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LastCallCreated_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LastCallCreated_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LastCallCreated view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LastCallCreated_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LastCallCreated]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LastEmailCreated_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LastEmailCreated_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LastEmailCreated_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LastEmailCreated view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LastEmailCreated_Get_List

AS


                    
                    SELECT
                        [LastEmailCreated]
                    FROM
                        [dbo].[vw_LastEmailCreated]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LastEmailCreated_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LastEmailCreated_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LastEmailCreated_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LastEmailCreated view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LastEmailCreated_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LastEmailCreated]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadCallCounts_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadCallCounts_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadCallCounts_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadCallCounts view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadCallCounts_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [Last Name],
                        [First Name],
                        [Call Count],
                        [Created Time],
                        [Lead Status],
                        [Rating],
                        [Lead Owner]
                    FROM
                        [dbo].[vw_LeadCallCounts]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadCallCounts_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadCallCounts_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadCallCounts_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadCallCounts view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadCallCounts_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadCallCounts]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadContactTool_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadContactTool_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadContactTool_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadContactTool view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadContactTool_Get_List

AS


                    
                    SELECT
                        [First Name],
                        [Last Name],
                        [Last Visited Time],
                        [Lead Owner],
                        [LEADID],
                        [Created Time]
                    FROM
                        [dbo].[vw_LeadContactTool]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadContactTool_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadContactTool_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadContactTool_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadContactTool view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadContactTool_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadContactTool]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadContactToolComplete_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadContactToolComplete_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadContactToolComplete_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadContactToolComplete view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadContactToolComplete_Get_List

AS


                    
                    SELECT
                        [First Name],
                        [Last Name],
                        [LEADID],
                        [ThisEventDts],
                        [LeadContactPhone],
                        [LeadContactEmail],
                        [LeadContactDts]
                    FROM
                        [dbo].[vw_LeadContactToolComplete]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadContactToolComplete_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadContactToolComplete_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadContactToolComplete_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadContactToolComplete view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadContactToolComplete_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadContactToolComplete]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGet_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGet_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGet_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadGet view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGet_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id]
                    FROM
                        [dbo].[vw_LeadGet]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGet_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGet_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGet_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadGet view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGet_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadGet]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetAlex_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetAlex_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetAlex_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadGetAlex view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetAlex_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Priority],
                        [Lead Owner Id],
                        [Total Calls]
                    FROM
                        [dbo].[vw_LeadGetAlex]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetAlex_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetAlex_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetAlex_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadGetAlex view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetAlex_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadGetAlex]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetCraig_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetCraig_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetCraig_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadGetCraig view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetCraig_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Priority],
                        [Lead Owner Id],
                        [Total Calls]
                    FROM
                        [dbo].[vw_LeadGetCraig]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetCraig_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetCraig_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetCraig_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadGetCraig view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetCraig_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadGetCraig]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetJenn_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetJenn_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetJenn_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadGetJenn view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetJenn_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Priority],
                        [Lead Owner Id],
                        [Total Calls]
                    FROM
                        [dbo].[vw_LeadGetJenn]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetJenn_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetJenn_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetJenn_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadGetJenn view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetJenn_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadGetJenn]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetJoEllen_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetJoEllen_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetJoEllen_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadGetJoEllen view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetJoEllen_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Priority],
                        [Lead Owner Id],
                        [Total Calls]
                    FROM
                        [dbo].[vw_LeadGetJoEllen]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetJoEllen_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetJoEllen_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetJoEllen_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadGetJoEllen view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetJoEllen_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadGetJoEllen]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetNext_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetNext_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetNext_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadGetNext view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetNext_Get_List

AS


                    
                    SELECT
                        [Lead Status],
                        [LEADID],
                        [Created Time],
                        [Email],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Rating],
                        [State],
                        [Time Zone],
                        [Phone],
                        [Rank],
                        [Lead Owner],
                        [USER_ID],
                        [LeadHoldDts],
                        [LeadActionDts]
                    FROM
                        [dbo].[vw_LeadGetNext]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetNext_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetNext_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetNext_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadGetNext view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetNext_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadGetNext]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetRichard_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetRichard_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetRichard_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadGetRichard view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetRichard_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Priority],
                        [Lead Owner Id],
                        [Total Calls]
                    FROM
                        [dbo].[vw_LeadGetRichard]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadGetRichard_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadGetRichard_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadGetRichard_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadGetRichard view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadGetRichard_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadGetRichard]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadHoldAndCall_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadHoldAndCall_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadHoldAndCall_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadHoldAndCall view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadHoldAndCall_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [USER_ID],
                        [LeadHoldAndCallPK],
                        [LeadHoldDts],
                        [LeadCalled],
                        [LeadDefered],
                        [LeadActionDts]
                    FROM
                        [dbo].[vw_LeadHoldAndCall]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadHoldAndCall_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadHoldAndCall_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadHoldAndCall_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadHoldAndCall view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadHoldAndCall_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadHoldAndCall]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadsAndCalls_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadsAndCalls_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadsAndCalls_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadsAndCalls view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadsAndCalls_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [Last Name],
                        [First Name],
                        [Created Time],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Rating],
                        [Lead Status],
                        [Time Zone],
                        [Call Duration (in minutes)],
                        [Call Purpose],
                        [Call Result],
                        [Call Start Time],
                        [CreatedBy],
                        [Subject]
                    FROM
                        [dbo].[vw_LeadsAndCalls]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadsAndCalls_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadsAndCalls_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadsAndCalls_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadsAndCalls view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadsAndCalls_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadsAndCalls]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadsWithAllStatus_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadsWithAllStatus_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadsWithAllStatus_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadsWithAllStatus view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadsWithAllStatus_Get_List

AS


                    
                    SELECT
                        [Lead Status],
                        [LEADID],
                        [Created Time],
                        [Email],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Rating],
                        [State],
                        [Time Zone],
                        [Phone],
                        [LeadHoldDts],
                        [LeadActionDts]
                    FROM
                        [dbo].[vw_LeadsWithAllStatus]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadsWithAllStatus_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadsWithAllStatus_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadsWithAllStatus_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadsWithAllStatus view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadsWithAllStatus_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadsWithAllStatus]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadsWithCallableStatus_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadsWithCallableStatus_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadsWithCallableStatus_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_LeadsWithCallableStatus view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadsWithCallableStatus_Get_List

AS


                    
                    SELECT
                        [Lead Status],
                        [LEADID],
                        [Created Time],
                        [Email],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Rating],
                        [State],
                        [Time Zone],
                        [Phone],
                        [LeadHoldDts],
                        [LeadActionDts]
                    FROM
                        [dbo].[vw_LeadsWithCallableStatus]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_LeadsWithCallableStatus_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_LeadsWithCallableStatus_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_LeadsWithCallableStatus_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_LeadsWithCallableStatus view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_LeadsWithCallableStatus_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_LeadsWithCallableStatus]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_MANUAL_ReturnsList_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_MANUAL_ReturnsList_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_MANUAL_ReturnsList_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_MANUAL_ReturnsList view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_MANUAL_ReturnsList_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [First Name],
                        [Last Name],
                        [Lead Status]
                    FROM
                        [dbo].[vw_MANUAL_ReturnsList]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_MANUAL_ReturnsList_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_MANUAL_ReturnsList_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_MANUAL_ReturnsList_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_MANUAL_ReturnsList view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_MANUAL_ReturnsList_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_MANUAL_ReturnsList]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_MANUAL_SalesList_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_MANUAL_SalesList_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_MANUAL_SalesList_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_MANUAL_SalesList view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_MANUAL_SalesList_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [First Name],
                        [Last Name],
                        [Lead Status]
                    FROM
                        [dbo].[vw_MANUAL_SalesList]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_MANUAL_SalesList_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_MANUAL_SalesList_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_MANUAL_SalesList_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_MANUAL_SalesList view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_MANUAL_SalesList_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_MANUAL_SalesList]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_MaxLeadHoldAndCall_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_MaxLeadHoldAndCall_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_MaxLeadHoldAndCall_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_MaxLeadHoldAndCall view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_MaxLeadHoldAndCall_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [LeadHoldDts],
                        [LeadActionDts]
                    FROM
                        [dbo].[vw_MaxLeadHoldAndCall]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_MaxLeadHoldAndCall_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_MaxLeadHoldAndCall_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_MaxLeadHoldAndCall_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_MaxLeadHoldAndCall view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_MaxLeadHoldAndCall_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_MaxLeadHoldAndCall]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_REPORTING_LeadsAndSalesBoard_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_REPORTING_LeadsAndSalesBoard_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_REPORTING_LeadsAndSalesBoard_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_REPORTING_LeadsAndSalesBoard view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_REPORTING_LeadsAndSalesBoard_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [First Name],
                        [Last Name],
                        [Created Time],
                        [LeadCreateDate],
                        [Sold to Person],
                        [Sale Date]
                    FROM
                        [dbo].[vw_REPORTING_LeadsAndSalesBoard]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_REPORTING_LeadsAndSalesBoard_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_REPORTING_LeadsAndSalesBoard_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_REPORTING_LeadsAndSalesBoard_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_REPORTING_LeadsAndSalesBoard view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_REPORTING_LeadsAndSalesBoard_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_REPORTING_LeadsAndSalesBoard]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_REPORTING_SalesInfo_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_REPORTING_SalesInfo_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_REPORTING_SalesInfo_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_REPORTING_SalesInfo view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_REPORTING_SalesInfo_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [First Name],
                        [Last Name],
                        [Created Time],
                        [LeadCreateDate],
                        [Sold to Person],
                        [Sale Date],
                        [DaysToSale],
                        [CallCount]
                    FROM
                        [dbo].[vw_REPORTING_SalesInfo]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_REPORTING_SalesInfo_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_REPORTING_SalesInfo_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_REPORTING_SalesInfo_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_REPORTING_SalesInfo view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_REPORTING_SalesInfo_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_REPORTING_SalesInfo]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_REPORTING_ZohoCallsConnectedAfterDate view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get_List

AS


                    
                    SELECT
                        [ACCOUNTID],
                        [Billable],
                        [Call Duration],
                        [Call Duration (in minutes)],
                        [Call Duration (in seconds)],
                        [Call Owner],
                        [Call Owner Id],
                        [Call Purpose],
                        [Call Result],
                        [Call Start Time],
                        [Call Type],
                        [ContactID],
                        [CreatedBy],
                        [Created Time],
                        [LEADID],
                        [Modified Time],
                        [POTENTIALID],
                        [RELATED To],
                        [SEMODULE],
                        [Subject],
                        [TASKID],
                        [Who Id Id],
                        [CallPK]
                    FROM
                        [dbo].[vw_REPORTING_ZohoCallsConnectedAfterDate]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_REPORTING_ZohoCallsConnectedAfterDate view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_REPORTING_ZohoCallsConnectedAfterDate_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_REPORTING_ZohoCallsConnectedAfterDate]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_SalesStats_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_SalesStats_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_SalesStats_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_SalesStats view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_SalesStats_Get_List

AS


                    
                    SELECT
                        [ExternUserCode],
                        [First Name],
                        [Last Name],
                        [Created Time],
                        [SaleDate],
                        [DaysToSale],
                        [InstallDate],
                        [CallCount]
                    FROM
                        [dbo].[vw_SalesStats]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_SalesStats_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_SalesStats_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_SalesStats_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_SalesStats view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_SalesStats_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_SalesStats]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoCalls_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoCalls_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoCalls_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_ZohoCalls view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoCalls_Get_List

AS


                    
                    SELECT
                        [TASKID],
                        [CallPK]
                    FROM
                        [dbo].[vw_ZohoCalls]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoCalls_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoCalls_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoCalls_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_ZohoCalls view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoCalls_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_ZohoCalls]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeads_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeads_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeads_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_ZohoLeads view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeads_Get_List

AS


                    
                    SELECT
                        [LEADID],
                        [LEADPK]
                    FROM
                        [dbo].[vw_ZohoLeads]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeads_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeads_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeads_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_ZohoLeads view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeads_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_ZohoLeads]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsNeedingActionToday_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsNeedingActionToday_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsNeedingActionToday_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_ZohoLeadsNeedingActionToday view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsNeedingActionToday_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun11-2],
                        [Sun8-11],
                        [Sun2-5],
                        [Sun5-8],
                        [USER_ID],
                        [LeadHoldDts],
                        [LeadCalled],
                        [LeadDefered],
                        [LeadActionDts]
                    FROM
                        [dbo].[vw_ZohoLeadsNeedingActionToday]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsNeedingActionToday_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsNeedingActionToday_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsNeedingActionToday_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_ZohoLeadsNeedingActionToday view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsNeedingActionToday_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_ZohoLeadsNeedingActionToday]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsWithLocalTime_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsWithLocalTime_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsWithLocalTime_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_ZohoLeadsWithLocalTime view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsWithLocalTime_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun8-11],
                        [Sun11-2],
                        [Sun2-5],
                        [Sun5-8],
                        [Lead Owner Id],
                        [Phone]
                    FROM
                        [dbo].[vw_ZohoLeadsWithLocalTime]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsWithLocalTime_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsWithLocalTime_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsWithLocalTime_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_ZohoLeadsWithLocalTime view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsWithLocalTime_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_ZohoLeadsWithLocalTime]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_ZohoLeadsWithLocalTimeNoActionToday view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun11-2],
                        [Sun8-11],
                        [Sun2-5],
                        [Sun5-8],
                        [USER_ID],
                        [LeadHoldDts],
                        [LeadCalled],
                        [LeadDefered],
                        [LeadActionDts],
                        [Lead Owner Id],
                        [Phone]
                    FROM
                        [dbo].[vw_ZohoLeadsWithLocalTimeNoActionToday]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_ZohoLeadsWithLocalTimeNoActionToday view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionToday_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_ZohoLeadsWithLocalTimeNoActionToday]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets all records from the vw_ZohoLeadsWithLocalTimeNoActionTodayCallable view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get_List

AS


                    
                    SELECT
                        [Created By],
                        [Created Time],
                        [First Name],
                        [Last Name],
                        [If No Longer Interested],
                        [Last Activity Time],
                        [Last Visited Time],
                        [Lead Owner],
                        [Lead Source],
                        [Lead Status],
                        [LEADID],
                        [Rating],
                        [State],
                        [Time Zone],
                        [LocalTime],
                        [URL],
                        [Website],
                        [Worries],
                        [LEADPK],
                        [WDay8-11],
                        [WDay11-2],
                        [WDay2-5],
                        [WDay5-8],
                        [Sat8-11],
                        [Sat11-2],
                        [Sat2-5],
                        [Sat5-8],
                        [Sun11-2],
                        [Sun8-11],
                        [Sun2-5],
                        [Sun5-8],
                        [USER_ID],
                        [LeadHoldDts],
                        [LeadCalled],
                        [LeadDefered],
                        [LeadActionDts],
                        [Lead Owner Id]
                    FROM
                        [dbo].[vw_ZohoLeadsWithLocalTimeNoActionTodayCallable]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, May 12, 2016

-- Created By: SafeInHome ()
-- Purpose: Gets records from the vw_ZohoLeadsWithLocalTimeNoActionTodayCallable view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.vw_ZohoLeadsWithLocalTimeNoActionTodayCallable_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[vw_ZohoLeadsWithLocalTimeNoActionTodayCallable]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

