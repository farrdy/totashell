<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns="http://www.w3.org/TR/xhtml1/strict">
    <xsl:output method="html" indent="yes" version="4.0"/>

    <xsl:template match="/">
    <xsl:for-each select="//Instance">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Confirmation</title>
</head>
<body>

        
    <p>
    Central Routing and Scheduling has resolved the standing dry instance logged 
    by <xsl:value-of select="Name"/> on tank number <xsl:value-of select="idTank"/> 
    of <xsl:value-of select="ProductName"/>. 
    The site was dry as from <xsl:value-of select="substring-before(substring-after(substring-after(DateDryFrom, '/'), '/'),' ')"/>/<xsl:value-of select="substring-before(DateDryFrom, '/')"/>/<xsl:value-of select="substring-before(substring-after(DateDryFrom, '/'),'/')"/> <xsl:text> </xsl:text>  <xsl:value-of select=" substring-after(DateDryFrom, ' ')"/>.  to         <xsl:value-of select="substring-before(substring-after(substring-after(DateDryTo, '/'), '/'),' ')"/>/<xsl:value-of select="substring-before(DateDryTo, '/')"/>/<xsl:value-of select="substring-before(substring-after(DateDryTo, '/'),'/')"/> <xsl:text> </xsl:text>  <xsl:value-of select=" substring-after(DateDryTo, ' ')"/>. Please review their comments on the dealer communication website against that instance.
     </p>
    
    <p>	NOTE: "This is a system generated email, please do not reply to this"	</p>
</body>
</html>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>