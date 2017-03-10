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
         To <xsl:value-of select="Name"/></p>
    <p>
		According to our information, the instance of standing dry you have reported has been resolved. Please refer to your logged instance on the dealer communication website to check the details captured by TOTAL. Should this information not be accurate, you are requested to advise your NBC / Regional Sales Manager / Retail Operations Manager accordingly.
	</p>
    <p>	NOTE: "This is a system generated email, please do not reply to this"	</p>

</body>
</html>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>