<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/Menus">
    <MenuItems>
      <xsl:call-template name="MenuListing"/>         
    </MenuItems>
  </xsl:template>

  <!-- Allow for recursive child nodeprocessing -->
  <xsl:template name="MenuListing">
    <xsl:apply-templates select="Menu" />
    </xsl:template>

    <xsl:template match="Menu">
      <MenuItem>
        
        <!-- Convert Menu child elements to MenuItem attributes -->
        <xsl:attribute name="Text">
          <xsl:value-of select="MenuCaption"/>
          </xsl:attribute>
            <xsl:attribute name="NavigateUrl">              
              <xsl:value-of select="URL"/>
              </xsl:attribute>

              <!-- Recursively call MenuListing forchild menu nodes -->
              <xsl:if test="count(Menu) >0">
                <xsl:call-template name="MenuListing" />
              </xsl:if>
            </MenuItem>
    </xsl:template>
</xsl:stylesheet>
