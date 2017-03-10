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
        We hereby acknowledge that you have retracted your standing dry instance 
        originally logged on <xsl:value-of select="substring-before(substring-after(substring-after(DateLogged, '/'), '/'),' ')"/>/<xsl:value-of select="substring-before(DateLogged, '/')"/>/<xsl:value-of select="substring-before(substring-after(DateLogged, '/'),'/')"/> <xsl:text> </xsl:text>  <xsl:value-of select=" substring-after(DateLogged, ' ')"/>. 
        No further action will be taken by TOTAL to resolve that instance.</p>

<p>	NOTE: "This is a system generated email, please do not reply to this"	</p>
</body>
</html>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>