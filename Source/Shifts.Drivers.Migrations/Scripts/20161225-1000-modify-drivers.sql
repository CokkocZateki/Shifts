﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE Drivers 
ADD Guid UniqueIdentifier NOT NULL 
GO

SET ANSI_PADDING OFF
GO

