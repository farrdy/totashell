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
        <xsl:value-of select="Name"/> has reported an instance of standing dry on 
        tank number <xsl:value-of select="idTank"/> of <xsl:value-of select="ProductName"/> as from 
        <xsl:value-of select="substring-before(substring-after(substring-after(DateDryFrom, '/'), '/'),' ')"/>/<xsl:value-of select="substring-before(DateDryFrom, '/')"/>/<xsl:value-of select="substring-before(substring-after(DateDryFrom, '/'),'/')"/> <xsl:text> </xsl:text>  <xsl:value-of select=" substring-after(DateDryFrom, ' ')"/>. 
        Please ensure that the instance is resolved and updated on the dealer 
        communication website.
    </p>
   <p>	NOTE: "This is a system generated email, please do not reply to this"</p>

</body>
</html>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>