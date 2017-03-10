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
        Thank you for bringing to our attention that your site is 
        standing dry. Our Central Routing and Scheduling and Retail Operations 
        departments have received your notification and will endeavour to 
        prioritise a delivery to your site as soon as possible. 
        You can keep track of your logged instance directly on the dealer 
        communication website and TOTAL will advise you as soon as the 
        standing dry instance has been resolved.</p>
<p>	NOTE: "This is a system generated email, please do not reply to this"	</p>

</body>
</html>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>