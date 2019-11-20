USE [easyauthdemo]
GO

SET IDENTITY_INSERT [Lookup] ON
GO

DECLARE @now DateTime2;
SELECT @now = GETUTCDATE();

DECLARE @me nvarchar(max);
SELECT @me = '(setup)';
MERGE INTO [Lookup] AS Target
USING (
	VALUES
(
		1, 
		'System.Lookup.Types', 
		'System.Lookup.Types',
		'Lookup Types',
		10, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		2, 
		'System.Lookup.Types', 
		'System.Lookup.StatusValues',
		'Status Values',
		20, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		3, 
		'System.Lookup.Types', 
		'System.AdditionalSearchField.Role',
		'Additional Search Field Role',
		30, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		4, 
		'System.Lookup.Types', 
		'System.ConfigurationValue.Category',
		'Config Value Category',
		40, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		5, 
		'System.Lookup.Types', 
		'System.ConfigurationValue.Scope',
		'Config Value Scope',
		50, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		6, 
		'System.Lookup.Types', 
		'System.Property.DatabaseType',
		'Property Database Type',
		60, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		7, 
		'System.Lookup.Types', 
		'System.Property.DataType',
		'Property Type',
		70, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		8, 
		'System.Lookup.Types', 
		'System.Property.Role',
		'Property Role',
		80, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		9, 
		'System.Lookup.Types', 
		'System.Template.CategoryType',
		'Template Category Type',
		90, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		10, 
		'System.Lookup.Types', 
		'System.Template.TemplateType',
		'Template Type',
		100, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		11, 
		'System.Lookup.Types', 
		'System.ConfigurationValue.Function',
		'Config Value Function',
		110, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		12, 
		'System.Lookup.StatusValues', 
		'Active',
		'Active',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		13, 
		'System.Lookup.StatusValues', 
		'Inactive',
		'Inactive',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		14, 
		'System.AdditionalSearchField.Role', 
		'search',
		'search',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		15, 
		'System.AdditionalSearchField.Role', 
		'placeholder',
		'placeholder',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		16, 
		'System.ConfigurationValue.Category', 
		'core',
		'core',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		17, 
		'System.ConfigurationValue.Category', 
		'standard',
		'standard',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		18, 
		'System.ConfigurationValue.Scope', 
		'class',
		'class',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		19, 
		'System.ConfigurationValue.Scope', 
		'property',
		'property',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		20, 
		'System.Property.DatabaseType', 
		'nvarchar',
		'nvarchar',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		21, 
		'System.Property.DatabaseType', 
		'int',
		'int',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		22, 
		'System.Property.DatabaseType', 
		'datetime',
		'datetime',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		23, 
		'System.Property.DatabaseType', 
		'float',
		'float',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		24, 
		'System.Property.DatabaseType', 
		'timestamp',
		'timestamp',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		25, 
		'System.Property.DatabaseType', 
		'bit',
		'bit',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		26, 
		'System.Property.DataType', 
		'string',
		'string',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		27, 
		'System.Property.DataType', 
		'int',
		'int',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		28, 
		'System.Property.DataType', 
		'float',
		'float',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		29, 
		'System.Property.DataType', 
		'DateTime',
		'DateTime',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		30, 
		'System.Property.DataType', 
		'byte[]',
		'byte[]',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		31, 
		'System.Property.DataType', 
		'bool',
		'bool',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		32, 
		'System.Property.DataType', 
		'*domainclass',
		'*domainclass',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		33, 
		'System.Property.Role', 
		'Default',
		'Default',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		34, 
		'System.Property.Role', 
		'LookupValue',
		'LookupValue',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		35, 
		'System.Property.Role', 
		'NavigationProperty',
		'NavigationProperty',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		36, 
		'System.Property.Role', 
		'HideInListView',
		'HideInListView',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		37, 
		'System.Property.Role', 
		'AttributeCollection',
		'AttributeCollection',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		38, 
		'System.Property.Role', 
		'OneToManyCollection',
		'OneToManyCollection',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		39, 
		'System.Property.Role', 
		'ForeignKey',
		'ForeignKey',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		40, 
		'System.Property.Role', 
		'PrimaryKey',
		'PrimaryKey',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		41, 
		'System.Property.Role', 
		'Audit',
		'Audit',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		42, 
		'System.Property.Role', 
		'Concurrency',
		'Concurrency',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		43, 
		'System.Template.CategoryType', 
		'NewProject.WebApiAngular',
		'NewProject.WebApiAngular',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		44, 
		'System.Template.CategoryType', 
		'NewProject.WebUi',
		'NewProject.WebUi',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		45, 
		'System.Template.CategoryType', 
		'.NET Common Code',
		'.NET Common Code',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		46, 
		'System.Template.CategoryType', 
		'.NET Core Adapters',
		'.NET Core Adapters',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		47, 
		'System.Template.CategoryType', 
		'.NET Core Domain Models',
		'.NET Core Domain Models',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		48, 
		'System.Template.CategoryType', 
		'.NET Core Security',
		'.NET Core Security',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		49, 
		'System.Template.CategoryType', 
		'.NET Core Service Layers',
		'.NET Core Service Layers',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		50, 
		'System.Template.CategoryType', 
		'.NET Core Unit Test Utilities',
		'.NET Core Unit Test Utilities',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		51, 
		'System.Template.CategoryType', 
		'.NET Core Validators',
		'.NET Core Validators',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		52, 
		'System.Template.CategoryType', 
		'ASP.NET Integration Tests',
		'ASP.NET Integration Tests',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		53, 
		'System.Template.CategoryType', 
		'ASP.NET MVC',
		'ASP.NET MVC',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		54, 
		'System.Template.CategoryType', 
		'ASP.NET MVC HTML UI',
		'ASP.NET MVC HTML UI',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		55, 
		'System.Template.CategoryType', 
		'ASP.NET Web API',
		'ASP.NET Web API',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		56, 
		'System.Template.CategoryType', 
		'EF Core',
		'EF Core',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		57, 
		'System.Template.CategoryType', 
		'SQL Server',
		'SQL Server',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		58, 
		'System.Template.CategoryType', 
		'Angular',
		'Angular',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		59, 
		'System.Template.TemplateType', 
		'LookupValues',
		'LookupValues',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		60, 
		'System.Template.TemplateType', 
		'PerClass',
		'PerClass',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		61, 
		'System.Template.TemplateType', 
		'PerClassPropertyLoop',
		'PerClassPropertyLoop',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		62, 
		'System.Template.TemplateType', 
		'PerProject',
		'PerProject',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		63, 
		'System.Template.TemplateType', 
		'PerProjectBinary',
		'PerProjectBinary',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		64, 
		'System.Template.TemplateType', 
		'UtilityClassAdditionalFields',
		'UtilityClassAdditionalFields',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		65, 
		'System.Template.TemplateType', 
		'UtilityClassLoopConditional',
		'UtilityClassLoopConditional',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		66, 
		'System.Template.TemplateType', 
		'UtilityPerClass',
		'UtilityPerClass',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		67, 
		'System.Template.TemplateType', 
		'UtilityPropertyLoopConditional',
		'UtilityPropertyLoopConditional',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		68, 
		'System.ConfigurationValue.Function', 
		'None',
		'None',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		69, 
		'System.ConfigurationValue.Function', 
		'ConvertCsharpDataTypeToTypescript',
		'ConvertCsharpDataTypeToTypescript',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		70, 
		'System.ConfigurationValue.Function', 
		'EscapeForSqIServer',
		'EscapeForSqIServer',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		71, 
		'System.ConfigurationValue.Function', 
		'GetAngularDefaultValueVariableName',
		'GetAngularDefaultValueVariableName',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		72, 
		'System.ConfigurationValue.Function', 
		'IfOrElself',
		'IfOrElself',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		73, 
		'System.ConfigurationValue.Function', 
		'Pluralize',
		'Pluralize',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		74, 
		'System.ConfigurationValue.Function', 
		'ToCamelCase',
		'ToCamelCase',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		75, 
		'System.ConfigurationValue.Function', 
		'ToLowerCase',
		'ToLowerCase',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		76, 
		'System.ConfigurationValue.Function', 
		'ToPascalCase',
		'ToPascalCase',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	),

(
		77, 
		'System.ConfigurationValue.Function', 
		'ToTypescriptFileFormat',
		'ToTypescriptFileFormat',
		0, 
		'Active', 
		@me, @now, 
		@me, @now	
	))

AS Source (Id, LookupType, LookupKey, LookupValue, DisplayOrder, Status, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
ON Target.Id = Source.Id
WHEN MATCHED THEN UPDATE SET
	LookupType = Source.LookupType,
	LookupKey = Source.LookupKey,
	LookupValue = Source.LookupValue,
	DisplayOrder = Source.DisplayOrder,
	Status = Source.Status,
	CreatedBy = Source.CreatedBy,
	CreatedDate = Source.CreatedDate,
	LastModifiedBy = Source.LastModifiedBy,
	LastModifiedDate = Source.LastModifiedDate
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, LookupType, LookupKey, LookupValue, DisplayOrder, Status, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
	VALUES (Id, LookupType, LookupKey, LookupValue, DisplayOrder, Status, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
;
GO
