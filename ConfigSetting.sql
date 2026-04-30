INSERT INTO [dbo].[ConfigSetting]
           ([SettingCD]
           ,[SettingGroupCD]
           ,[SettingDisplayName]
           ,[DisplayOrder]
           ,[DefaultValues]
           ,[FormControlCD]
           ,[DataTypeCD]
           ,[MaxLength]
           ,[IsActive]
           ,[CreatedDate]
           ,[CreatedBy])
     VALUES
           ('TalbotCatalystSFTPHost'
           ,'Services Authentication'
           ,'Talbot Catalyst SFTP Host'
           ,1
           ,'Host'
           ,'TEXTAREA'
           ,'ALPHA_TEXT'
           ,100
           ,1
           ,GETDATE()
           ,'Admin')


		   INSERT INTO [dbo].[ConfigSetting]
           ([SettingCD]
           ,[SettingGroupCD]
           ,[SettingDisplayName]
           ,[DisplayOrder]
           ,[DefaultValues]
           ,[FormControlCD]
           ,[DataTypeCD]
           ,[MaxLength]
           ,[IsActive]
           ,[CreatedDate]
           ,[CreatedBy])
     VALUES
           ('TalbotCatalystSFTPUserName'
           ,'Services Authentication'
           ,'Talbot Catalyst SFTP UserName'
           ,1
           ,'User Name'
           ,'TEXTAREA'
           ,'ALPHA_TEXT'
           ,100
           ,1
           ,GETDATE()
           ,'Admin')



		   INSERT INTO [dbo].[ConfigSetting]
           ([SettingCD]
           ,[SettingGroupCD]
           ,[SettingDisplayName]
           ,[DisplayOrder]
           ,[DefaultValues]
           ,[FormControlCD]
           ,[DataTypeCD]
           ,[MaxLength]
           ,[IsActive]
           ,[CreatedDate]
           ,[CreatedBy])
     VALUES
           ('TalbotCatalystSFTPPassword'
           ,'Services Authentication'
           ,'Talbot Catalyst SFTP Password'
           ,1
           ,'Password'
           ,'TEXTAREA'
           ,'ALPHA_TEXT'
           ,100
           ,1
           ,GETDATE()
           ,'Admin')



