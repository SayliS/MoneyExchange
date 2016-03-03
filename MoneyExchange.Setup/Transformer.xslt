<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:wix="http://schemas.microsoft.com/wix/2006/wi">
  <xsl:output method="xml" indent="yes" />
  <xsl:strip-space elements="*"/>


  <xsl:variable name="CompanyName">MG Technologies</xsl:variable>
  <xsl:variable name="ProductName">MoneyExchange</xsl:variable>
  <xsl:variable name="UpgradeCode">aec77d2e-b102-491d-8ca4-ba6b5b4b661f</xsl:variable>

  <xsl:variable name="Component1">MoneyExchangeService</xsl:variable>
  <xsl:variable name="Component1_Title">MoneyExchangeService</xsl:variable>
  <xsl:variable name="Component1_ServiceExe">MoneyExchange.WS.exe</xsl:variable>
  <xsl:variable name="Component1_ServiceName">MoneyExchangeService</xsl:variable>
  <xsl:variable name="Component1_ServiceDescr">Eurosys integration with OANDA</xsl:variable>

  <xsl:template match='/'>
    <Wix xmlns="http://schemas.microsoft.com/wix/2006/wi" xmlns:util="http://schemas.microsoft.com/wix/UtilExtension">

      <Product Id="*" Name="{$ProductName}" Language="1033" Version="1.0.0.0" Manufacturer="{$CompanyName}" UpgradeCode="{$UpgradeCode}">
        <Package InstallerVersion="200" Compressed="yes" InstallScope="perMachine" />

        <MajorUpgrade DowngradeErrorMessage="A newer version of {$ProductName} is already installed." />
        <MediaTemplate EmbedCab="yes" />

        <Feature Id="{$Component1}" Title="{$Component1_Title}" Level="1">
          <ComponentGroupRef Id="{$Component1}_ServiceComponents" />
        </Feature>
      </Product>

      <Fragment>
        <Directory Id="TARGETDIR" Name="SourceDir">
          <Directory Id="ProgramFilesFolder">
            <Directory Id="CompanyFolder" Name="{$CompanyName}">
              <Directory Id="ProductFolder" Name="{$ProductName}">
                <Directory Id="{$Component1}_INSTALLFOLDER" Name="{$Component1}" />
              </Directory>
            </Directory>
          </Directory>
        </Directory>
      </Fragment>

      <Fragment>
        <ComponentGroup Id="{$Component1}_ServiceComponents">
          <Component Id="{$Component1}_ServiceComponent" Directory="{$Component1}_INSTALLFOLDER" Guid="ab621e57-b52d-4bbe-853e-a5f0ca312a73">
            <xsl:call-template name="Component1_ReferencesTemplate" />
            <ServiceInstall
  Id="QBServiceInstaller"
  Type="ownProcess"
  Vital="yes"
  Name="{$Component1_ServiceName}"
  DisplayName="{$Component1_ServiceName}"
  Description="{$Component1_ServiceDescr}"
  Start="auto"
  Account="LocalSystem"
  ErrorControl="ignore"
  Interactive="no"
						>
              <!--<ServiceDependency Id="[DependencyServiceName]"/>-->
              <!--<util:PermissionEx
									User="Authenticated Users"
									GenericAll="yes"
									ServiceChangeConfig="yes"
									ServiceEnumerateDependents="yes"
									ChangePermission="yes"
									ServiceInterrogate="yes"
									ServicePauseContinue="yes"
									ServiceQueryConfig="yes"
									ServiceQueryStatus="yes"
									ServiceStart="yes"
									ServiceStop="yes" />-->
            </ServiceInstall>
            <ServiceControl Id="{$Component1}StartService" Start="install" Stop="both" Remove="uninstall" Name="{$Component1_ServiceName}" Wait="yes" />
          </Component>

        </ComponentGroup>

      </Fragment>

    </Wix>
  </xsl:template>

  <xsl:template name="Component1_ReferencesTemplate" match="@*|node()">
    <xsl:copy>
      <xsl:for-each select="wix:Wix/wix:Fragment/wix:ComponentGroup/wix:Component/wix:File[@Source and not (contains(@Source, '.pdb')) and not (contains(@Source, '.vshost.'))]">
        <xsl:apply-templates select="."/>
      </xsl:for-each>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="wix:Wix/wix:Fragment/wix:ComponentGroup/wix:Component/wix:File">
    <xsl:copy>
      <xsl:choose>
        <xsl:when test="not (contains(@Source, 'MoneyExchangeWS.exe')) or (contains(@Source, '.config'))">
          <xsl:apply-templates select="@*[name()!='KeyPath']"/>
          <xsl:attribute name="Vital">
            <xsl:value-of select="'yes'"/>
          </xsl:attribute>
        </xsl:when>
        <xsl:otherwise>
          <xsl:apply-templates select="@*"/>
          <xsl:attribute name="Vital">
            <xsl:value-of select="'yes'"/>
          </xsl:attribute>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:copy>
  </xsl:template>

</xsl:stylesheet>